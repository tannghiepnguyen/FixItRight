using AutoMapper;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Identity;

namespace FixItRight_Service.TransactionServices
{
	internal sealed class TransactionService : ITransactionService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;

		public TransactionService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
			this.userManager = userManager;
		}

		private async Task<Booking> CheckBookingExist(Guid bookingId, bool trackChange)
		{
			var booking = await repositoryManager.BookingRepository.GetBookingById(bookingId, trackChange);
			if (booking is null) throw new BookingNotFoundException(bookingId);
			return booking;
		}

		private async Task CheckUserExist(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) throw new UserNotFoundException(userId);
		}

		public async Task<TransactionForReturnDto> CreateTransaction(TransactionForCreationDto transaction)
		{
			var transactionEntity = mapper.Map<Transaction>(transaction);
			transactionEntity.CreatedAt = DateTime.Now;
			repositoryManager.TransactionRepository.CreateTransaction(transactionEntity);
			await repositoryManager.SaveAsync();
			return mapper.Map<TransactionForReturnDto>(transactionEntity);
		}

		public async Task<TransactionForReturnDto?> GetTransactionByBookingId(Guid bookingId, bool trackChange)
		{
			var transaction = await CheckBookingExist(bookingId, trackChange);
			return mapper.Map<TransactionForReturnDto>(transaction);
		}

		public async Task<IEnumerable<TransactionForReturnDto>> GetTransactionsByUserId(string userId, bool trackChange)
		{
			await CheckUserExist(userId);
			var transactions = await repositoryManager.TransactionRepository.GetTransactionsByUserId(userId, trackChange);
			return mapper.Map<IEnumerable<TransactionForReturnDto>>(transactions);
		}

		public async Task<IEnumerable<TransactionForReturnDto>> GetTransactions(bool trackChange)
		{
			var transactions = await repositoryManager.TransactionRepository.GetTransactions(trackChange);
			return mapper.Map<IEnumerable<TransactionForReturnDto>>(transactions);
		}
	}
}
