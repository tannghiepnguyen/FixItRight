using FixItRight_Domain.Constants;
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
		public string? Address { get; set; }
		[Required]
		public string PhoneNumber { get; init; }
		public string? CccdFront { get; init; }
		public string? CccdBack { get; init; }
		public string? Avatar { get; init; }
	}
}
