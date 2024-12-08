using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.RatingServices.DTOs;

namespace FixItRight_Service.RatingServices
{
	public interface IRatingService
	{
		Task<RatingForReturnDto> CreateRating(RatingForCreationDto ratingForCreationDto);
		Task<RatingForReturnDto> GetRatingByBookingId(Guid bookingId, bool trackChange);
		Task<(IEnumerable<RatingForReturnDto> ratings, MetaData metaData)> GetRatings(RatingParameters ratingParameters, bool trackChange);
	}
}
