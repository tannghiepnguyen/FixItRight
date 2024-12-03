namespace FixItRight_Domain.Models
{
	public class Chat
	{
		public Guid Id { get; set; }
		public string Message { get; set; }
		public DateTime CreatedAt { get; set; }
		public string SenderId { get; set; }
		public User Sender { get; set; }
		public Guid BookingId { get; set; }
		public Booking Booking { get; set; }
	}
}
