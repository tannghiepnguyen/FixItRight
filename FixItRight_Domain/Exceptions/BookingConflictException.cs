namespace FixItRight_Domain.Exceptions
{
	public class BookingConflictException : ConflictException
	{
		public BookingConflictException(string? message) : base(message)
		{
		}
	}
}
