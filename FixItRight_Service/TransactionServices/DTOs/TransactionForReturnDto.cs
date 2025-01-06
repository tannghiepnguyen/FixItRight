using FixItRight_Domain.Constants;

namespace FixItRight_Service.TransactionServices.DTOs
{
	public record TransactionForReturnDto
	{
		public Guid Id { get; init; }
		public double Amount { get; init; }
		public DateTime CreatedAt { get; init; }
		public Guid BookingId { get; init; }
		public TransactionStatus Status { get; init; }
		public string UserId { get; init; }
	}
}
