using FixItRight_Domain.Models;
using FixItRight_Domain.RequestFeatures;

namespace FixItRight_Domain.Repositories
{
	public interface IRepairServiceRepository
	{
		Task<PagedList<Service>> GetRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange);
		Task<Service?> GetRepairServiceByIdAsync(Guid id, bool trackChange);
		Task<PagedList<Service>> GetActiveRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange);
		void AddRepairServiceAsync(Service repairService);
		void DeleteRepairServiceAsync(Service repairService);
	}
}
