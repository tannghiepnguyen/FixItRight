using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public record ServiceForUpdateDto
	{
		public string? Image { get; init; }
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
		[Required]
		public double Price { get; init; }
		[Required]
		public Guid CategoryId { get; init; }
	}
}
