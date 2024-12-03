using FixItRight_Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForRegistrationDto
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
		public string Password { get; init; }
		[Required]
		public string PhoneNumber { get; init; }
	}
}
