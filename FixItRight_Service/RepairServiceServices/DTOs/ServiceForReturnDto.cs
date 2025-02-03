using FixItRight_Service.CategoryServices.DTOs;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public record ServiceForReturnDto
	{
		public Guid Id { get; init; }
		public string? Image { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public double Price { get; init; }
		public bool Active { get; init; }
		public CategoryForReturnDto Category { get; init; }
	}
}
