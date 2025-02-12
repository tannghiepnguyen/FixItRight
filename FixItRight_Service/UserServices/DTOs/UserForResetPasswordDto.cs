using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForResetPasswordDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; init; }
		[Required]
		public string Token { get; init; }
		[Required]
		public string Password { get; init; }
		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; init; }
	}
}
