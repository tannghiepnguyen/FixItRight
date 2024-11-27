using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;

namespace FixItRight_Infrastructure.Repositories
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext repositoryContext;
		private readonly Lazy<IRepairServiceRepository> repairServiceRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			this.repositoryContext = repositoryContext;
			this.repairServiceRepository = new Lazy<IRepairServiceRepository>(() => new RepairServiceRepository(this.repositoryContext));
		}
		public IRepairServiceRepository RepairService => repairServiceRepository.Value;

		public void Save() => repositoryContext.SaveChanges();
	}
}
