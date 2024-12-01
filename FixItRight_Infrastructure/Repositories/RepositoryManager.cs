using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;

namespace FixItRight_Infrastructure.Repositories
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext repositoryContext;
		private readonly Lazy<IRepairServiceRepository> repairServiceRepository;
		private readonly Lazy<IRatingRepository> ratingRepository;
		private readonly Lazy<IBookingRepository> bookingRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			this.repositoryContext = repositoryContext;
			this.repairServiceRepository = new Lazy<IRepairServiceRepository>(() => new RepairServiceRepository(this.repositoryContext));
			this.ratingRepository = new Lazy<IRatingRepository>(() => new RatingRepository(this.repositoryContext));
			this.bookingRepository = new Lazy<IBookingRepository>(() => new BookingRepository(this.repositoryContext));
		}
		public IRepairServiceRepository RepairService => repairServiceRepository.Value;

		public IRatingRepository RatingRepository => ratingRepository.Value;

		public IBookingRepository BookingRepository => bookingRepository.Value;

		public Task SaveAsync() => repositoryContext.SaveChangesAsync();
	}
}
