using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
	{
		public RatingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateRating(Rating rating) => Create(rating);

		public async Task<double> GetAverageRatingByMechanistId(string mechanistId)
		{
			var ratings = FindAll(false).AsSplitQuery().Include(c => c.Booking).ThenInclude(c => c.Mechanist).Where(c => c.Booking.MechanistId.Equals(mechanistId));
			if (await ratings.CountAsync() == 0) return 0;
			return await ratings.AverageAsync(c => c.Score);
		}

		public async Task<Rating?> GetRatingByBookingId(Guid bookingId, bool trackChange) => await FindByCondition(r => r.BookingId.Equals(bookingId), trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<Rating>> GetRatings(RatingParameters ratingParameters, bool trackChange)
		{
			var bookings = await FindAll(trackChange).ToListAsync();
			return PagedList<Rating>.ToPagedList(bookings, ratingParameters.PageNumber, ratingParameters.PageSize);
		}
	}
}
