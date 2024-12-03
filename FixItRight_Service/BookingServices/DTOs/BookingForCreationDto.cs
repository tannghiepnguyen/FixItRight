namespace FixItRight_Service.BookingServices.DTOs
{
	public record BookingForCreationDto
	{
		public string CustomerId { get; init; }
		public string MechanistId { get; init; }
		public Guid ServiceId { get; init; }
	}
}
