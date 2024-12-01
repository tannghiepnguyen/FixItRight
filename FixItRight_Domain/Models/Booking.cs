using FixItRight_Domain.Constants;

namespace FixItRight_Domain.Models
{
	public class Booking
	{
		public Guid Id { get; set; }
		public string CustomerId { get; set; }
		public User Customer { get; set; }
		public string MechanistId { get; set; }
		public User Mechanist { get; set; }
		public Guid ServiceId { get; set; }
		public Service Service { get; set; }
		public DateTime BookingDate { get; set; }
		public BookingStatus Status { get; set; }
		public Rating Rating { get; set; }
		public Transaction Transaction { get; set; }
		public ICollection<Chat> Chats { get; set; }
	}
}
