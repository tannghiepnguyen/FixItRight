using Microsoft.AspNetCore.Http;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public record ServiceForCreationDto
	{
		public IFormFile File { get; init; }
		public string Name { get; init; }
		public string Description { get; init; }
		public double Price { get; init; }
	}
}
