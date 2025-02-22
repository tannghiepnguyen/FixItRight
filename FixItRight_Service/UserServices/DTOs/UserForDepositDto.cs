namespace FixItRight_Service.UserServices.DTOs
{
	public record UserForDepositDto
	{
		public string UserId { get; init; }
		public double Amount { get; init; }
	}
}
