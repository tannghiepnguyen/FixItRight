using AutoMapper;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.RepairServiceServices.DTOs;

namespace FixItRight_Service.RepairServiceServices
{
	internal sealed class RepairServiceService : IRepairServiceService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;
		private readonly IBlobService blobService;

		public RepairServiceService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IBlobService blobService)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
			this.blobService = blobService;
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

		public async Task<(IEnumerable<ServiceForReturnDto> services, MetaData metaData)> GetActiveRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange)
		{
			var servicesWithMetaData = await repositoryManager.RepairService.GetActiveRepairServicesAsync(repairServiceParameters, trackChange);
			var services = mapper.Map<IEnumerable<ServiceForReturnDto>>(servicesWithMetaData);
			return (services, servicesWithMetaData.MetaData);
		}

		public async Task<ServiceForReturnDto?> GetRepairServiceByIdAsync(Guid id, bool trackChange)
		{
			var service = await CheckServiceExist(id, trackChange);
			return mapper.Map<ServiceForReturnDto>(service);
		}

		public async Task<(IEnumerable<ServiceForReturnDto> services, MetaData metaData)> GetRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange)
		{
			var servicesWithMetaData = await repositoryManager.RepairService.GetRepairServicesAsync(repairServiceParameters, trackChange);
			var services = mapper.Map<IEnumerable<ServiceForReturnDto>>(servicesWithMetaData);
			return (services, servicesWithMetaData.MetaData);
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
