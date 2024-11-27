using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;

namespace FixItRight_Infrastructure.Repositories
{
	public class RepairServiceRepository : RepositoryBase<Service>, IRepairServiceRepository
	{
		public RepairServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}
	}
}
