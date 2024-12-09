using FixItRight_Domain.Models;
using FixItRight_Domain.RequestFeatures;

namespace FixItRight_Domain.Repositories
{
	public interface IRatingRepository
	{
		void CreateRating(Rating rating);
		Task<Rating?> GetRatingByBookingId(Guid bookingId, bool trackChange);
		Task<PagedList<Rating>> GetRatings(RatingParameters ratingParameters, bool trackChange);

		Task<double> GetAverageRatingByMechanistId(string mechanistId);
	}
}
