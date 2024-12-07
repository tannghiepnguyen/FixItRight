using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class RepairServiceRepository : RepositoryBase<Service>, IRepairServiceRepository
	{
		public RepairServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void AddRepairServiceAsync(Service repairService) => Create(repairService);

		public void DeleteRepairServiceAsync(Service repairService) => Delete(repairService);

		public async Task<PagedList<Service>> GetActiveRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange)
		{
			var services = await FindByCondition(s => s.Active, trackChange).ToListAsync();
			return PagedList<Service>.ToPagedList(services, repairServiceParameters.PageNumber, repairServiceParameters.PageSize);
		}

		public async Task<Service?> GetRepairServiceByIdAsync(Guid id, bool trackChange) => await FindByCondition(s => s.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<Service>> GetRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange)
		{
			var services = await FindAll(trackChange).ToListAsync();
			return PagedList<Service>.ToPagedList(services, repairServiceParameters.PageNumber, repairServiceParameters.PageSize);
		}

	}
}
