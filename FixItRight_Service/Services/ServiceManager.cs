using AutoMapper;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.IServices;
using FixItRight_Service.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FixItRight_Service.Services
{
	public sealed class ServiceManager : IServiceManager
	{
		private readonly Lazy<IUserService> userService;
		public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
		{
			userService = new Lazy<IUserService>(() => new UserService(logger, mapper, userManager, configuration));
		}
		public IUserService UserService => userService.Value;
	}
}
