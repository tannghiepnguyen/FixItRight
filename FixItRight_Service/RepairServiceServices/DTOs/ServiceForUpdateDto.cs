using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.RepairServiceServices.DTOs
{
	public record ServiceForUpdateDto
	{
		[Required]
		public IFormFile File { get; init; }
		[Required]
		public string Name { get; init; }
		[Required]
		public string Description { get; init; }
		[Required]
		public double Price { get; init; }
	}
}
