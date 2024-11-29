using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
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

		public async Task<IEnumerable<Service>> GetActiveRepairServicesAsync(bool trackChange) => await FindByCondition(s => s.Active, trackChange).ToListAsync();

		public async Task<Service?> GetRepairServiceByIdAsync(Guid id, bool trackChange) => await FindByCondition(s => s.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<Service>> GetRepairServicesAsync(bool trackChange) => await FindAll(trackChange).ToListAsync();

	}
}
