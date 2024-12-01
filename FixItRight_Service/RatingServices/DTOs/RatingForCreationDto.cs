namespace FixItRight_Service.RatingServices.DTOs
{
	public record RatingForCreationDto
	{
		public double Score { get; init; }
		public string Comment { get; init; }
		public Guid BookingId { get; init; }
	}
}
