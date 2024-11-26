namespace FixItRight_Domain.Models
{
	public class Chat
	{
		public Guid Id { get; set; }
		public string Message { get; set; }
		public DateTime CreatedAt { get; set; }
		public string CustomerId { get; set; }
		public User Customer { get; set; }
		public string MechanistId { get; set; }
		public User Mechanist { get; set; }
	}
}
