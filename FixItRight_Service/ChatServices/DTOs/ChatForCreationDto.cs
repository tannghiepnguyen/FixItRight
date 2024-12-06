namespace FixItRight_Service.ChatServices.DTOs
{
	public record ChatForCreationDto
	{
		public string Message { get; init; }
		public string SenderId { get; init; }
		public Guid BookingId { get; init; }
	}
}
