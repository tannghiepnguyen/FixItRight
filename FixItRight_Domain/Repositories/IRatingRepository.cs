using FixItRight_Domain.Models;

namespace FixItRight_Domain.Repositories
{
	public interface IRatingRepository
	{
		void CreateRating(Rating rating);
		Task<Rating?> GetRatingByBookingId(Guid bookingId, bool trackChange);
		Task<IEnumerable<Rating>> GetRatings(bool trackChange);
	}
}
