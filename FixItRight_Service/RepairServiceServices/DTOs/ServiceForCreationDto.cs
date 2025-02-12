using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public record ServiceForCreationDto
	{
		[Required]
		public string File { get; init; }
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
