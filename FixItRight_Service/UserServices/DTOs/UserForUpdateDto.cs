using FixItRight_Domain.Constants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForUpdateDto
	{
		[Required]
		public string Fullname { get; init; }
		[Required]
		public Gender Gender { get; init; }
		[Required]
		public DateOnly Birthday { get; init; }
		[Required]
		public string UserName { get; init; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Password { get; init; }
		[Required]
		public string PhoneNumber { get; init; }
		public IFormFile? CccdFront { get; init; }
		public IFormFile? CccdBack { get; init; }
		public IFormFile? Avatar { get; init; }
	}
}
