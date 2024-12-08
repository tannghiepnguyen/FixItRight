using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
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

		public async Task<PagedList<Booking>> GetBookings(BookingParameters bookingParameters, bool trackChange)
		{
			var bookings = await FindAll(trackChange).Include(c => c.Rating).ToListAsync();
			return PagedList<Booking>.ToPagedList(bookings, bookingParameters.PageNumber, bookingParameters.PageSize);
		}
	}
}
