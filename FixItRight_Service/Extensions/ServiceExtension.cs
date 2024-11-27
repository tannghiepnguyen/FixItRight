using Microsoft.Extensions.DependencyInjection;

namespace FixItRight_Service.Extensions
{
	public static class ServiceExtension
	{
		public static void ConfigureAutomapper(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(ServiceExtension).Assembly);
		}
	}
}
