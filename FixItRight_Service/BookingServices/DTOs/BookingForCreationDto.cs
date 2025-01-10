namespace FixItRight_Service.BookingServices.DTOs
{
	public record BookingForCreationDto
	{
		public string CustomerId { get; init; }
		public Guid ServiceId { get; init; }
		public DateOnly WorkingDate { get; init; }
		public string Address { get; init; }
		public TimeOnly WorkingTime { get; init; }
	}
}
