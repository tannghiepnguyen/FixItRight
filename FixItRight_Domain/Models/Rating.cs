namespace FixItRight_Domain.Models
{
	public class Rating
	{
		public Guid Id { get; set; }
		public double Score { get; set; }
		public string Comment { get; set; }
		public Guid BookingId { get; set; }
		public Booking Booking { get; set; }
	}
}
