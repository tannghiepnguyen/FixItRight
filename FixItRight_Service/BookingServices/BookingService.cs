using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.BookingServices.DTOs;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FixItRight_Service.BookingServices
{
	internal sealed class BookingService : IBookingService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;
		private readonly Utils utils;
		private readonly UserManager<User> userManager;

		private async Task<Booking> CheckBookingExist(Guid bookingId, bool trackChange)
		{
			var booking = await repositoryManager.BookingRepository.GetBookingById(bookingId, trackChange);
			if (booking is null) throw new BookingNotFoundException(bookingId);
			return booking;
		}

		public BookingService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IConfiguration configuration, Utils utils, UserManager<User> userManager)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
			this.configuration = configuration;
			this.utils = utils;
			this.userManager = userManager;
		}
		private async Task<User> GetRandomMechanist()
		{
			var mechanists = await userManager.GetUsersInRoleAsync(Role.Mechanist.ToString());
			var random = new Random();
			var randomMechanist = mechanists.ElementAt(random.Next(mechanists.Count));
			return randomMechanist;
		}
		public async Task CreateBooking(BookingForCreationDto bookingForCreationDto)
		{
			var service = await repositoryManager.RepairService.GetRepairServiceByIdAsync(bookingForCreationDto.ServiceId, false);

			var user = await userManager.FindByIdAsync(bookingForCreationDto.CustomerId);
			if (user.Balance < service.Price) throw new NotEnoughMoneyException("You don't have enough money to use service");

			var booking = mapper.Map<Booking>(bookingForCreationDto);
			booking.Id = Guid.NewGuid();
			booking.Status = BookingStatus.Pending;
			booking.BookingDate = DateTime.Now;
			booking.MechanistId = (await GetRandomMechanist()).Id;
			repositoryManager.BookingRepository.CreateBooking(booking);

			user.Balance -= service.Price;
			await userManager.UpdateAsync(user);

			await repositoryManager.SaveAsync();
		}

		public async Task<BookingForReturnDto?> GetBookingById(Guid bookingId, bool trackChange)
		{
			var booking = await CheckBookingExist(bookingId, trackChange);
			return mapper.Map<BookingForReturnDto>(booking);
		}

		public async Task UpdateBooking(Guid bookingId, BookingForUpdateDto bookingForUpdateDto, bool trackChange)
		{
			var booking = await CheckBookingExist(bookingId, trackChange);
			var service = await repositoryManager.RepairService.GetRepairServiceByIdAsync(booking.ServiceId, false);
			var user = await userManager.FindByIdAsync(booking.CustomerId);
			if (bookingForUpdateDto.Status == BookingStatus.Cancelled)
			{
				user.Balance += service.Price;
				await userManager.UpdateAsync(user);
			}
			mapper.Map(bookingForUpdateDto, booking);
			await repositoryManager.SaveAsync();
		}

		public async Task<(IEnumerable<BookingForReturnDto> bookings, MetaData metaData)> GetBookings(BookingParameters bookingParameters, bool trackChange)
		{
			var bookingsWithMetaData = await repositoryManager.BookingRepository.GetBookings(bookingParameters, trackChange);
			var bookings = mapper.Map<IEnumerable<BookingForReturnDto>>(bookingsWithMetaData);
			return (bookings, bookingsWithMetaData.MetaData);
		}

		public async Task<(IEnumerable<BookingForReturnDto> bookings, MetaData metaData)> GetBookingsByMechanistId(BookingParameters bookingParameters, string mechanistId, bool trackChange)
		{
			var bookingsWithMetaData = await repositoryManager.BookingRepository.GetBookingByMechanistId(bookingParameters, mechanistId, trackChange);
			var bookings = mapper.Map<IEnumerable<BookingForReturnDto>>(bookingsWithMetaData);
			return (bookings, bookingsWithMetaData.MetaData);
		}

		public async Task<(IEnumerable<BookingForReturnDto> bookings, MetaData metaData)> GetBookingsByCustomerId(BookingParameters bookingParameters, string customerId, bool trackChange)
		{
			var bookingsWithMetaData = await repositoryManager.BookingRepository.GetBookingByCustomerId(bookingParameters, customerId, trackChange);
			var bookings = mapper.Map<IEnumerable<BookingForReturnDto>>(bookingsWithMetaData);
			return (bookings, bookingsWithMetaData.MetaData);
		}

		public async Task DeleteBooking(Guid bookingId)
		{
			var booking = await CheckBookingExist(bookingId, false);
			if (booking.Status != BookingStatus.Pending) throw new BookingConflictException("You cannot delete your booking anymore");
			var user = await userManager.FindByIdAsync(booking.CustomerId);
			var service = await repositoryManager.RepairService.GetRepairServiceByIdAsync(booking.ServiceId, false);
			user.Balance += service.Price;
			await userManager.UpdateAsync(user);
			repositoryManager.BookingRepository.DeleteBooking(booking);
			await repositoryManager.SaveAsync();
		}
	}
}
