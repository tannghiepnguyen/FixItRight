using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;
using FixItRight_Infrastructure.Repositories;
using FixItRight_Service.IServices;
using FixItRight_Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_API.Extension
{
	public static class ServiceExtensions
	{
		public static void ConfigureIdentity(this IServiceCollection services)
		{
			var builder = services.AddIdentity<User, IdentityRole>(o =>
			{
				o.Password.RequireDigit = false;
				o.Password.RequireLowercase = false;
				o.Password.RequireUppercase = false;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 5;
			})
			.AddEntityFrameworkStores<RepositoryContext>()
			.AddDefaultTokenProviders();
		}

		public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<RepositoryContext>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DbString")));
		}

		public static void ConfigureManager(this IServiceCollection services)
		{
			services.AddScoped<IRepositoryManager, RepositoryManager>();
			services.AddScoped<IServiceManager, ServiceManager>();
		}

		public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();

		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
					builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());
			});
	}
}
