using FixItRight_Domain.Constants;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForRegistrationDto
	{
		public string Fullname { get; init; }
		public Gender Gender { get; init; }
		public DateOnly Birthday { get; init; }
		public string UserName { get; init; }
		public string Password { get; init; }
		public string PhoneNumber { get; init; }
	}
}
