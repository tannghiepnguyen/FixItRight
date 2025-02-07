using FixItRight_Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForRegistrationDto
	{
		public string? Fullname { get; init; }
		public Gender? Gender { get; init; }
		public DateOnly? Birthday { get; init; }
		public string? Address { get; init; }
		[Required]
		public string UserName { get; init; }
		[Required]
		public string Password { get; init; }
		[Required]
		public string Email { get; init; }
	}
}
