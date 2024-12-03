using AutoMapper;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.BookingServices;
using FixItRight_Service.IServices;
using FixItRight_Service.RatingServices;
using FixItRight_Service.RepairServiceServices;
using FixItRight_Service.TransactionServices;
using FixItRight_Service.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FixItRight_Service.Services
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> userService;
		private readonly Lazy<IRepairServiceService> repairServiceService;
		private readonly Lazy<IRatingService> ratingService;
		private readonly Lazy<IBookingService> bookingService;
		private readonly Lazy<ITransactionService> transactionService;
		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
		{
			userService = new Lazy<IUserService>(() => new UserService(logger, mapper, userManager, configuration));
			repairServiceService = new Lazy<IRepairServiceService>(() => new RepairServiceService(repositoryManager, logger, mapper));
			ratingService = new Lazy<IRatingService>(() => new RatingService(repositoryManager, logger, mapper));
			bookingService = new Lazy<IBookingService>(() => new BookingService(repositoryManager, logger, mapper));
			transactionService = new Lazy<ITransactionService>(() => new TransactionService(repositoryManager, logger, mapper, userManager));
		}
		public IUserService UserService => userService.Value;

		public IRepairServiceService RepairServiceService => repairServiceService.Value;

		public IRatingService RatingService => ratingService.Value;

		public IBookingService BookingService => bookingService.Value;

		public ITransactionService TransactionService => transactionService.Value;
	}
}
