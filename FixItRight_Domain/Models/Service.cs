namespace FixItRight_Domain.Models
{
	public class Service
	{
		public Guid Id { get; set; }
		public string? Image { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }
		public bool Active { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ICollection<Booking> Bookings { get; set; }
	}
}
