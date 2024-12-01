namespace FixItRight_Domain.Repositories
{
	public interface IRepositoryManager
	{
		IRepairServiceRepository RepairService { get; }
		IRatingRepository RatingRepository { get; }
		IBookingRepository BookingRepository { get; }
		Task SaveAsync();
	}
}
