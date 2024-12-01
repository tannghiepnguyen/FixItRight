using AutoMapper;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.IServices;
using FixItRight_Service.RatingServices;
using FixItRight_Service.RepairServiceServices;
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
		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
		{
			userService = new Lazy<IUserService>(() => new UserService(logger, mapper, userManager, configuration));
			repairServiceService = new Lazy<IRepairServiceService>(() => new RepairServiceService(repositoryManager, logger, mapper));
			ratingService = new Lazy<IRatingService>(() => new RatingService(repositoryManager, logger, mapper));
		}
		public IUserService UserService => userService.Value;

		public IRepairServiceService RepairServiceService => repairServiceService.Value;

		public IRatingService RatingService => ratingService.Value;
	}
}
