using FixItRight_Service.RatingServices;
using FixItRight_Service.RepairServiceServices;
using FixItRight_Service.UserServices;

namespace FixItRight_Service.IServices
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
		IRepairServiceService RepairServiceService { get; }
		IRatingService RatingService { get; }
	}
}
