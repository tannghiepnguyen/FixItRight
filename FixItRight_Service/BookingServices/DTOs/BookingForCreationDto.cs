namespace FixItRight_Service.BookingServices.DTOs
{
	public record BookingForCreationDto
	{
		public string CustomerId { get; init; }
		public Guid ServiceId { get; init; }
	}
}
