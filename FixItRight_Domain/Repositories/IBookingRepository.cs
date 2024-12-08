using FixItRight_Domain.Models;
using FixItRight_Domain.RequestFeatures;

namespace FixItRight_Domain.Repositories
{
	public interface IBookingRepository
	{
		Task<PagedList<Booking>> GetBookings(BookingParameters bookingParameters, bool trackChange);
		Task<Booking?> GetBookingById(Guid bookingId, bool trackChange);
		void CreateBooking(Booking booking);
	}
}
