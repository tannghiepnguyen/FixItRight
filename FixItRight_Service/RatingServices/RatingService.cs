using AutoMapper;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.IServices;
using FixItRight_Service.RatingServices.DTOs;

namespace FixItRight_Service.RatingServices
{
	internal sealed class RatingService : IRatingService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;

		public RatingService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
		}

		private async Task<Booking> CheckBookingExist(Guid bookingId, bool trackChange)
		{
			var booking = await repositoryManager.BookingRepository.GetBookingById(bookingId, trackChange);
			if (booking is null) throw new BookingNotFoundException(bookingId);
			return booking;
		}

		public async Task<RatingForReturnDto> CreateRating(RatingForCreationDto ratingForCreationDto)
		{
			var rating = mapper.Map<Rating>(ratingForCreationDto);
			repositoryManager.RatingRepository.CreateRating(rating);
			await repositoryManager.SaveAsync();
			return mapper.Map<RatingForReturnDto>(rating);
		}

		public async Task<RatingForReturnDto> GetRatingByBookingId(Guid bookingId, bool trackChange)
		{
			var booking = await CheckBookingExist(bookingId, trackChange);
			return mapper.Map<RatingForReturnDto>(booking.Rating);
		}

		public async Task<IEnumerable<RatingForReturnDto>> GetRatings(bool trackChange)
		{
			var ratings = await repositoryManager.RatingRepository.GetRatings(trackChange);
			return mapper.Map<IEnumerable<RatingForReturnDto>>(ratings);
		}
	}
}
