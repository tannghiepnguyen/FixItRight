using FixItRight_Domain.Constants;

namespace FixItRight_Service.BookingServices.DTOs
{
	public record BookingForReturnDto
	{
		public Guid Id { get; init; }
		public string CustomerId { get; init; }
		public string MechanistId { get; init; }
		public Guid ServiceId { get; init; }
		public BookingStatus Status { get; init; }
		public DateTime BookingDate { get; init; }
	}
}
