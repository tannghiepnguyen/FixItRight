﻿using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

		private async Task<Transaction> CheckBookingExist(Guid bookingId, bool trackChange)
		{
			var booking = await repositoryManager.BookingRepository.GetBookingById(bookingId, trackChange);
			if (booking is null) throw new BookingNotFoundException(bookingId);
			return await repositoryManager.TransactionRepository.GetTransactionByBookingId(bookingId, trackChange);
		}

		private async Task CheckUserExist(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) throw new UserNotFoundException(userId);
		}

		private async Task<User> GetRandomMechanist()
		{
			var mechanists = await userManager.GetUsersInRoleAsync(Role.Mechanist.ToString());
			var random = new Random();
			var randomMechanist = mechanists.ElementAt(random.Next(mechanists.Count));
			return randomMechanist;
		}

		public async Task<string> CreateTransaction(TransactionForCreationDto transactionDto)
		{
			var transaction = mapper.Map<Transaction>(transactionDto);
			transaction.CreatedAt = DateTime.UtcNow;
			transaction.Status = TransactionStatus.Pending;
			repositoryManager.TransactionRepository.CreateTransaction(transaction);
			await repositoryManager.SaveAsync();

			var vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", "2.1.0");
			vnpay.AddRequestData("vnp_Command", "pay");
			vnpay.AddRequestData("vnp_TmnCode", configuration.GetSection("VNPay").GetSection("TmnCode").Value);
			vnpay.AddRequestData("vnp_Amount", (transactionDto.Amount * 100).ToString());
			vnpay.AddRequestData("vnp_CreateDate", DateTime.UtcNow.ToString("yyyyMMddHHmmss"));
			vnpay.AddRequestData("vnp_CurrCode", "VND");
			vnpay.AddRequestData("vnp_IpAddr", utils.GetIpAddress());
			vnpay.AddRequestData("vnp_Locale", "vn");
			vnpay.AddRequestData("vnp_OrderType", "other");
			vnpay.AddRequestData("vnp_OrderInfo", $"Payment for order {transaction.Id}");
			vnpay.AddRequestData("vnp_ReturnUrl", configuration.GetSection("VNPay").GetSection("ReturnUrlMobile").Value);
			vnpay.AddRequestData("vnp_TxnRef", transaction.Id.ToString());
			var paymentUrl = vnpay.CreateRequestUrl(configuration.GetSection("VNPay").GetSection("Url").Value, configuration.GetSection("VNPay").GetSection("HashSecret").Value);
			return paymentUrl; // Redirect to this URL for payment
		}

		public async Task<TransactionForReturnDto?> GetTransactionByBookingId(Guid bookingId, bool trackChange)
		{
			var transaction = await CheckBookingExist(bookingId, trackChange);
			return mapper.Map<TransactionForReturnDto>(transaction);
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

		public async Task<IActionResult> IPNAsync(IQueryCollection query)
		{
			var vnpay = new VnPayLibrary();
			foreach (var key in query.Keys)
			{
				if (key.StartsWith("vnp_"))
				{
					vnpay.AddResponseData(key, query[key]);
				}
			}

			var vnpSecureHash = query["vnp_SecureHash"];
			var isValid = vnpay.ValidateSignature(vnpSecureHash, configuration.GetSection("VNPay").GetSection("HashSecret").Value);

			if (!isValid)
			{
				return new JsonResult(new { RspCode = "97", Message = "Invalid signature" });
			}

			// Validate and update transaction status
			var transactionId = Guid.Parse(vnpay.GetResponseData("vnp_TxnRef"));
			var amount = long.Parse(vnpay.GetResponseData("vnp_Amount")) / 100;
			var responseCode = vnpay.GetResponseData("vnp_ResponseCode");
			var transaction = await repositoryManager.TransactionRepository.GetTransactionById(transactionId, true);
			var booking = await repositoryManager.BookingRepository.GetBookingById(transaction.BookingId, true);

			if (transaction == null)
			{
				return new JsonResult(new { RspCode = "01", Message = "Order not found" });
			}

			// Update transaction status based on response code
			if (responseCode == "00")
			{
				booking.MechanistId = (await GetRandomMechanist()).Id;
				transaction.Status = TransactionStatus.Success;
			}
			else
			{
				transaction.Status = TransactionStatus.Failed;
			}
			await repositoryManager.SaveAsync();

			return new JsonResult(new { RspCode = "00", Message = "Confirm Success" });
		}
	}
}
