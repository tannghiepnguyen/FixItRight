namespace FixItRight_Service.TransactionServices.DTOs
{
	public record TransactionForCreationDto
	{
		public double Amount { get; init; }
		public string UserId { get; init; }
	}
}
