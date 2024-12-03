using System.ComponentModel.DataAnnotations;

namespace FixItRight_Service.RatingServices.DTOs
{
	public record RatingForCreationDto
	{
		[Required]
		public double Score { get; init; }
		[Required]
		public string Comment { get; init; }
		[Required]
		public Guid BookingId { get; init; }
	}
}
