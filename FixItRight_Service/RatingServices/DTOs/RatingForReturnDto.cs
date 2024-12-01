namespace FixItRight_Service.RatingServices.DTOs
{
	public class RatingForReturnDto
	{
		public Guid Id { get; set; }
		public double Score { get; set; }
		public string Comment { get; set; }
		public Guid BookingId { get; init; }
	}
}
