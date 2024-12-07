using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.RepairServiceServices.DTOs;

namespace FixItRight_Service.RepairServiceServices
{
	public interface IRepairServiceService
	{
		Task<(IEnumerable<ServiceForReturnDto> services, MetaData metaData)> GetRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange);
		Task<(IEnumerable<ServiceForReturnDto> services, MetaData metaData)> GetActiveRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange);
		Task<ServiceForReturnDto?> GetRepairServiceByIdAsync(Guid id, bool trackChange);
		Task<ServiceForReturnDto> AddRepairServiceAsync(ServiceForCreationDto repairService);
		Task UpdateRepairServiceAsync(Guid id, ServiceForUpdateDto repairService, bool trackChange);
		Task DeleteRepairServiceAsync(Guid id, bool trackChange);
	}
}
