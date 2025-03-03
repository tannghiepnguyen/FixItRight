using FixItRight_Domain.Constants;
using FixItRight_Service.RatingServices.DTOs;
using FixItRight_Service.RepairServiceServices.DTOs;

namespace FixItRight_Service.BookingServices.DTOs
{
	public record BookingForReturnDto
	{
		public Guid Id { get; init; }
		public string CustomerId { get; init; }
		public string MechanistId { get; init; }
		public Guid ServiceId { get; init; }
		public ServiceForReturnDto Service { get; set; }
		public RatingForReturnDto Rating { get; set; }
		public DateOnly WorkingDate { get; init; }
		public string Address { get; init; }
		public TimeOnly WorkingTime { get; init; }
		public BookingStatus Status { get; init; }
		public DateTime BookingDate { get; init; }
		public string? Note { get; init; }
	}
}
