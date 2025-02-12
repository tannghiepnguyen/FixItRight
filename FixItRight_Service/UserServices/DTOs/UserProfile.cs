using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.UserServices.DTOs
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDto, User>();
			CreateMap<UserForUpdateDto, User>();
			CreateMap<User, UserForReturnDto>();
		}
	}
}
