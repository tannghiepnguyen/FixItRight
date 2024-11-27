namespace FixItRight_Domain.Repositories
{
	public interface IRepositoryManager
	{
		IRepairServiceRepository RepairService { get; }
		void Save();
	}
}
