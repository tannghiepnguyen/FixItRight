using FixItRight_Domain.Constants;

namespace FixItRight_Service.BookingServices.DTOs
{
	public record BookingForUpdateDto
	{
		public Guid Id { get; init; }
		public BookingStatus Status { get; init; }
	}
}
