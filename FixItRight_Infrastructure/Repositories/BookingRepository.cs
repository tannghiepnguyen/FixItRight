using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
	{
		public BookingRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateBooking(Booking booking) => Create(booking);

		public async Task<Booking?> GetBookingById(Guid bookingId, bool trackChange) => await FindByCondition(booking => booking.Id.Equals(bookingId), trackChange).Include(c => c.Rating).SingleOrDefaultAsync();
	}
}
