namespace FixItRight_Domain.Models
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public double Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public Guid BookingId { get; set; }
		public Booking Booking { get; set; }
	}
}
