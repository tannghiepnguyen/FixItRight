namespace FixItRight_Service.ChatServices.DTOs
{
	public class ChatForReturnDto
	{
		public Guid Id { get; init; }
		public DateTime CreatedAt { get; init; }
		public string Message { get; init; }
		public string SenderId { get; init; }
		public Guid BookingId { get; init; }
	}
}
