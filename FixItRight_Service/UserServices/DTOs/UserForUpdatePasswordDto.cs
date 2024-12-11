using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForUpdatePasswordDto
	{
		[Required]
		public string OldPassword { get; init; }
		[Required]
		public string NewPassword { get; init; }
	}
}
