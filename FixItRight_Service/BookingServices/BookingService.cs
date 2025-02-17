using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.BookingServices.DTOs;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices;
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

		private async Task<Booking> CheckBookingExist(Guid bookingId, bool trackChange)
		{
			var booking = await repositoryManager.BookingRepository.GetBookingById(bookingId, trackChange);
			if (booking is null) throw new BookingNotFoundException(bookingId);
			return booking;
		}

		public BookingService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IConfiguration configuration, Utils utils)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
			this.configuration = configuration;
			this.utils = utils;
		}
		public async Task<string> CreateBooking(BookingForCreationDto bookingForCreationDto)
		{
			var booking = mapper.Map<Booking>(bookingForCreationDto);
			booking.Id = Guid.NewGuid();
			booking.Status = BookingStatus.Pending;
			booking.BookingDate = DateTime.Now;
			repositoryManager.BookingRepository.CreateBooking(booking);

			var transaction = new Transaction
			{
				Id = Guid.NewGuid(),
				Amount = booking.Service.Price,
				CreatedAt = DateTime.Now,
				Status = TransactionStatus.Pending,
				BookingId = booking.Id,
				UserId = booking.CustomerId
			};
			repositoryManager.TransactionRepository.CreateTransaction(transaction);

			await repositoryManager.SaveAsync();

			var vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", "2.1.0");
			vnpay.AddRequestData("vnp_Command", "pay");
			vnpay.AddRequestData("vnp_TmnCode", configuration.GetSection("VNPay").GetSection("TmnCode").Value);
			vnpay.AddRequestData("vnp_Amount", (transaction.Amount * 100).ToString());
			vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
			vnpay.AddRequestData("vnp_CurrCode", "VND");
			vnpay.AddRequestData("vnp_IpAddr", utils.GetIpAddress());
			vnpay.AddRequestData("vnp_Locale", "vn");
			vnpay.AddRequestData("vnp_OrderType", "other");
			vnpay.AddRequestData("vnp_OrderInfo", $"Payment for order {transaction.Id}");
			vnpay.AddRequestData("vnp_ReturnUrl", configuration.GetSection("VNPay").GetSection("ReturnUrlMobile").Value);
			vnpay.AddRequestData("vnp_TxnRef", transaction.Id.ToString());
			var paymentUrl = vnpay.CreateRequestUrl(configuration.GetSection("VNPay").GetSection("Url").Value, configuration.GetSection("VNPay").GetSection("HashSecret").Value);
			return paymentUrl;
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
	}
}
