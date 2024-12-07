using FixItRight_Service.BookingServices.DTOs;

namespace FixItRight_Service.BookingServices
{
	public interface IBookingService
	{
		Task<BookingForReturnDto> CreateBooking(BookingForCreationDto bookingForCreationDto);
		Task<BookingForReturnDto?> GetBookingById(Guid bookingId, bool trackChange);
		Task UpdateBooking(Guid bookingId, BookingForUpdateDto bookingForUpdateDto, bool trackChange);
		Task<IEnumerable<BookingForReturnDto>> GetBookings(bool trackChange);
	}
}
