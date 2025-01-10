namespace FixItRight_Domain.Models
{
	public class Category
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public ICollection<Service> Services { get; set; }
	}
}
