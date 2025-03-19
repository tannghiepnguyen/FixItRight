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

		public void DeleteBooking(Booking booking) => Delete(booking);

		public async Task<PagedList<Booking>> GetBookingByCustomerId(BookingParameters bookingParameters, string customerId, bool trackChange)
		{
			var bookings = FindByCondition(booking => booking.CustomerId.Equals(customerId), trackChange);
			bookings = bookings.Where(c => c.Status == bookingParameters.Status);
			bookings = bookings.Include(c => c.Rating);
			bookings = bookings.Include(c => c.Service).ThenInclude(s => s.Category);
			return PagedList<Booking>.ToPagedList((await bookings.ToListAsync()), bookingParameters.PageNumber, bookingParameters.PageSize);
		}

		public async Task<Booking?> GetBookingById(Guid bookingId, bool trackChange) => await FindByCondition(booking => booking.Id.Equals(bookingId), trackChange).Include(c => c.Rating).Include(c => c.Service).ThenInclude(s => s.Category).SingleOrDefaultAsync();

		public async Task<PagedList<Booking>> GetBookingByMechanistId(BookingParameters bookingParameters, string mechanistId, bool trackChange)
		{
			var bookings = FindByCondition(booking => booking.MechanistId.Equals(mechanistId), trackChange);
			bookings = bookings.Where(c => c.Status == bookingParameters.Status);
			bookings = bookings.Include(c => c.Rating);
			bookings = bookings.Include(c => c.Service).ThenInclude(s => s.Category);
			return PagedList<Booking>.ToPagedList((await bookings.ToListAsync()), bookingParameters.PageNumber, bookingParameters.PageSize);
		}

		public async Task<PagedList<Booking>> GetBookings(BookingParameters bookingParameters, bool trackChange)
		{
			var bookings = FindAll(trackChange);
			bookings = bookings.Where(c => c.Status == bookingParameters.Status);
			bookings = bookings.Include(c => c.Rating);
			bookings = bookings.Include(c => c.Service).ThenInclude(s => s.Category);
			return PagedList<Booking>.ToPagedList((await bookings.ToListAsync()), bookingParameters.PageNumber, bookingParameters.PageSize);
		}

		public IQueryable<Booking> GetBookings(bool trackChange)
		{
			return FindByCondition(b => b.Status != FixItRight_Domain.Constants.BookingStatus.Cancelled, trackChange).Include(b => b.Service);
		}
	}
}
