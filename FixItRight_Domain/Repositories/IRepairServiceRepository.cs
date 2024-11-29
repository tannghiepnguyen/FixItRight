using FixItRight_Domain.Models;

namespace FixItRight_Domain.Repositories
{
	public interface IRepairServiceRepository
	{
		Task<IEnumerable<Service>> GetRepairServicesAsync(bool trackChange);
		Task<Service?> GetRepairServiceByIdAsync(Guid id, bool trackChange);
		Task<IEnumerable<Service>> GetActiveRepairServicesAsync(bool trackChange);
		void AddRepairServiceAsync(Service repairService);
		void DeleteRepairServiceAsync(Service repairService);
	}
}
