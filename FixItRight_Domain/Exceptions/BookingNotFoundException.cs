namespace FixItRight_Domain.Exceptions
{
	public class BookingNotFoundException : NotFoundException
	{
		public BookingNotFoundException(Guid bookingId) : base($"The booking with id: {bookingId} doesn't exist")
		{
		}
	}
}
