using FixItRight_Service.RepairServiceServices.DTOs;

namespace FixItRight_Service.RepairServiceServices
{
	public interface IRepairServiceService
	{
		Task<IEnumerable<ServiceForReturnDto>> GetRepairServicesAsync(bool trackChange);
		Task<IEnumerable<ServiceForReturnDto>> GetActiveRepairServicesAsync(bool trackChange);
		Task<ServiceForReturnDto?> GetRepairServiceByIdAsync(Guid id, bool trackChange);
		Task<ServiceForReturnDto> AddRepairServiceAsync(ServiceForCreationDto repairService);
		Task UpdateRepairServiceAsync(Guid id, ServiceForUpdateDto repairService, bool trackChange);
		Task DeleteRepairServiceAsync(Guid id, bool trackChange);
	}
}
