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

		public async Task<Rating?> GetRatingByBookingId(Guid bookingId, bool trackChange) => await FindByCondition(r => r.BookingId.Equals(bookingId), trackChange).SingleOrDefaultAsync();

		public async Task<PagedList<Rating>> GetRatings(RatingParameters ratingParameters, bool trackChange)
		{
			var bookings = await FindAll(trackChange).ToListAsync();
			return PagedList<Rating>.ToPagedList(bookings, ratingParameters.PageNumber, ratingParameters.PageSize);
		}
	}
}
