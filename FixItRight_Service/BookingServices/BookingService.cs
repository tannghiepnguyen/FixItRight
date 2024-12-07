using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.BookingServices.DTOs;
using FixItRight_Service.IServices;

namespace FixItRight_Service.BookingServices
{
	internal sealed class BookingService : IBookingService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;

		private async Task<Booking> CheckBookingExist(Guid bookingId, bool trackChange)
		{
			var booking = await repositoryManager.BookingRepository.GetBookingById(bookingId, trackChange);
			if (booking is null) throw new BookingNotFoundException(bookingId);
			return booking;
		}

		public BookingService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
		}
		public async Task<BookingForReturnDto> CreateBooking(BookingForCreationDto bookingForCreationDto)
		{
			var booking = mapper.Map<Booking>(bookingForCreationDto);
			booking.Status = BookingStatus.NotPaid;
			booking.BookingDate = DateTime.Now;
			repositoryManager.BookingRepository.CreateBooking(booking);
			await repositoryManager.SaveAsync();
			return mapper.Map<BookingForReturnDto>(booking);
		}

		public async Task<BookingForReturnDto?> GetBookingById(Guid bookingId, bool trackChange)
		{
			var booking = await CheckBookingExist(bookingId, trackChange);
			return mapper.Map<BookingForReturnDto>(booking);
		}

		public async Task UpdateBooking(Guid bookingId, BookingForUpdateDto bookingForUpdateDto, bool trackChange)
		{
			var booking = await CheckBookingExist(bookingId, trackChange);
			mapper.Map(bookingForUpdateDto, booking);
			await repositoryManager.SaveAsync();
		}

		public async Task<IEnumerable<BookingForReturnDto>> GetBookings(bool trackChange)
		{
			var bookings = await repositoryManager.BookingRepository.GetBookings(trackChange);
			return mapper.Map<IEnumerable<BookingForReturnDto>>(bookings);
		}
	}
}
