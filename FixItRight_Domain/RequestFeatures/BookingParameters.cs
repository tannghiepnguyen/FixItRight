using FixItRight_Domain.Constants;

namespace FixItRight_Domain.RequestFeatures
{
	public class BookingParameters : RequestParameters
	{
		public BookingStatus Status { get; init; } = BookingStatus.Pending;
	}
}
