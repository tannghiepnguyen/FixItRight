using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.UserServices.DTOs
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserForRegistrationDto, User>();
			CreateMap<UserForUpdateDto, User>().ForSourceMember(c => c.Avatar, opt => opt.DoNotValidate()).ForSourceMember(c => c.CccdFront, opt => opt.DoNotValidate()).ForSourceMember(c => c.CccdBack, opt => opt.DoNotValidate());
			CreateMap<User, UserForReturnDto>();
		}
	}
}
