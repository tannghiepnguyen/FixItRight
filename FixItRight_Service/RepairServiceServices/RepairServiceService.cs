using AutoMapper;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.IServices;
using FixItRight_Service.RepairServiceServices.DTOs;

namespace FixItRight_Service.RepairServiceServices
{
	internal sealed class RepairServiceService : IRepairServiceService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;

		public RepairServiceService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
		}
		private async Task<Service?> CheckServiceExist(Guid id, bool trackChange)
		{
			var service = await repositoryManager.RepairService.GetRepairServiceByIdAsync(id, trackChange);
			if (service is null) throw new ServiceNotFoundException(id);
			return service;
		}
		public async Task<ServiceForReturnDto> AddRepairServiceAsync(ServiceForCreationDto repairService)
		{
			var service = mapper.Map<Service>(repairService);
			service.Active = true;
			service.CreatedAt = DateTime.Now;
			repositoryManager.RepairService.AddRepairServiceAsync(service);
			await repositoryManager.SaveAsync();
			return mapper.Map<ServiceForReturnDto>(service);
		}

		public async Task DeleteRepairServiceAsync(Guid id, bool trackChange)
		{
			var service = await CheckServiceExist(id, trackChange);
			service.Active = false;
			await repositoryManager.SaveAsync();
		}

		public async Task<IEnumerable<ServiceForReturnDto>> GetActiveRepairServicesAsync(bool trackChange)
		{
			var services = await repositoryManager.RepairService.GetActiveRepairServicesAsync(trackChange);
			return mapper.Map<IEnumerable<ServiceForReturnDto>>(services);
		}

		public async Task<ServiceForReturnDto?> GetRepairServiceByIdAsync(Guid id, bool trackChange)
		{
			var service = await CheckServiceExist(id, trackChange);
			return mapper.Map<ServiceForReturnDto>(service);
		}

		public async Task<IEnumerable<ServiceForReturnDto>> GetRepairServicesAsync(bool trackChange)
		{
			var services = await repositoryManager.RepairService.GetRepairServicesAsync(trackChange);
			return mapper.Map<IEnumerable<ServiceForReturnDto>>(services);
		}

		public async Task UpdateRepairServiceAsync(Guid id, ServiceForUpdateDto repairService, bool trackChange)
		{
			var service = await CheckServiceExist(id, trackChange);
			mapper.Map(repairService, service);
			service.UpdatedAt = DateTime.Now;
			await repositoryManager.SaveAsync();
		}
	}
}
