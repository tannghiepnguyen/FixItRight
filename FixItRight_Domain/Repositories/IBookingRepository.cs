using FixItRight_Domain.Models;

namespace FixItRight_Domain.Repositories
{
	public interface IBookingRepository
	{
		Task<Booking?> GetBookingById(Guid bookingId, bool trackChange);
		void CreateBooking(Booking booking);
	}
}
