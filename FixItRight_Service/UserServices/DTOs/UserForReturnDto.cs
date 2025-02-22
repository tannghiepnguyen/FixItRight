using FixItRight_Domain.Constants;

namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForReturnDto
	{
		public string Id { get; init; }
		public bool Active { get; init; }
		public string? Avatar { get; init; }
		public string? Address { get; set; }
		public bool IsVerified { get; init; }
		public string Fullname { get; init; }
		public Gender Gender { get; init; }
		public DateOnly Birthday { get; init; }
		public string UserName { get; init; }
		public string Email { get; init; }
		public double Balance { get; init; }
		public IList<string> Roles { get; set; }
	}
}
