using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.RatingServices.DTOs
{
	public class RatingProfile : Profile
	{
		public RatingProfile()
		{
			CreateMap<RatingForCreationDto, Rating>();
			CreateMap<Rating, RatingForReturnDto>();
		}
	}
}
