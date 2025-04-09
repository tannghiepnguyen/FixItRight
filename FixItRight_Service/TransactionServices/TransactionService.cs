using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Net.payOS;
using Net.payOS.Types;

namespace FixItRight_Service.TransactionServices
{
	internal sealed class TransactionService : ITransactionService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly Utils utils;
		private readonly IConfiguration configuration;

		public TransactionService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, Utils utils, IConfiguration configuration)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
			this.userManager = userManager;
			this.utils = utils;
			this.configuration = configuration;
		}

		private async Task CheckUserExist(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) throw new UserNotFoundException(userId);
		}

		public async Task CreateTransaction(TransactionForCreationDto transactionDto)
		{
			Random random = new Random();
			var transaction = mapper.Map<FixItRight_Domain.Models.Transaction>(transactionDto);
			transaction.Id = Guid.NewGuid();
			transaction.OrderCode = random.Next(100000, 999999);
			transaction.CreatedAt = DateTime.Now;
			transaction.Status = TransactionStatus.Success;
			repositoryManager.TransactionRepository.CreateTransaction(transaction);

			var user = await userManager.FindByIdAsync(transaction.UserId);
			user.Balance += transaction.Amount;
			await userManager.UpdateAsync(user);
			await repositoryManager.SaveAsync();
		}

		public async Task<(IEnumerable<TransactionForReturnDto> transactions, MetaData metaData)> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange)
		{
			await CheckUserExist(userId);
			var transactionsWithMetaData = await repositoryManager.TransactionRepository.GetTransactionsByUserId(userId, transactionParameters, trackChange);
			var transactions = mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionsWithMetaData);
			return (transactions, transactionsWithMetaData.MetaData);
		}

		public async Task<(IEnumerable<TransactionForReturnDto> transactions, MetaData metaData)> GetTransactions(TransactionParameters transactionParameters, bool trackChange)
		{
			var transactionsWithMetaData = await repositoryManager.TransactionRepository.GetTransactions(transactionParameters, trackChange);
			var transactions = mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionsWithMetaData);
			return (transactions, transactionsWithMetaData.MetaData);
		}

		public record Responses(int error, String message, object? data);

		public async Task IPNAsync(WebhookData webhookData)
		{
			var transaction = await repositoryManager.TransactionRepository.GetTransactionById(webhookData.orderCode, true);
			var user = await userManager.FindByIdAsync(transaction.UserId);
			var clientId = configuration.GetSection("PayOSClientID").Value;
			var apiKey = configuration.GetSection("PayOSAPIKey").Value;
			var checksumKey = configuration.GetSection("PayOSChecksumKey").Value;

			var payOS = new PayOS(clientId, apiKey, checksumKey);
			if (webhookData.code == "00")
			{
				user.Balance += transaction.Amount;
				transaction.Status = TransactionStatus.Success;
				await userManager.UpdateAsync(user);
			}
			else
			{
				transaction.Status = TransactionStatus.Failed;
			}

			await repositoryManager.SaveAsync();

			//var vnpay = new VnPayLibrary();
			//foreach (var key in query.Keys)
			//{
			//	if (key.StartsWith("vnp_"))
			//	{
			//		vnpay.AddResponseData(key, query[key]);
			//	}
			//}

			//var vnpSecureHash = query["vnp_SecureHash"];
			//var isValid = vnpay.ValidateSignature(vnpSecureHash, configuration.GetSection("VNPay").GetSection("HashSecret").Value);

			//if (!isValid)
			//{
			//	return new JsonResult(new { RspCode = "97", Message = "Invalid signature" });
			//}

			//// Validate and update transaction status
			//var transactionId = Guid.Parse(vnpay.GetResponseData("vnp_TxnRef"));
			//var amount = long.Parse(vnpay.GetResponseData("vnp_Amount")) / 100;
			//var responseCode = vnpay.GetResponseData("vnp_ResponseCode");
			//var transaction = await repositoryManager.TransactionRepository.GetTransactionById(transactionId, true);
			//var user = await userManager.FindByIdAsync(transaction.UserId);

			//if (transaction == null)
			//{
			//	return new JsonResult(new { RspCode = "01", Message = "Order not found" });
			//}

			//// Update transaction status based on response code
			//if (responseCode == "00")
			//{
			//	user.Balance += amount;
			//	await userManager.UpdateAsync(user);
			//	transaction.Status = TransactionStatus.Success;
			//}
			//else
			//{
			//	transaction.Status = TransactionStatus.Failed;
			//}
			//await repositoryManager.SaveAsync();

			//return new JsonResult(new { RspCode = "00", Message = "Confirm Success" });
		}

		public async Task<int> GetNumberOfTransactions()
		{
			return await repositoryManager.TransactionRepository.GetTransactions(false).CountAsync();
		}

		public async Task<double> GetTotalMoney()
		{
			return await repositoryManager.TransactionRepository.GetTransactions(false).SumAsync(c => c.Amount);
		}
	}
}
