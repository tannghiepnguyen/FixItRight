using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.ChatServices.DTOs
{
	public class ChatProfile : Profile
	{
		public ChatProfile()
		{
			CreateMap<ChatForCreationDto, Chat>();
			CreateMap<Chat, ChatForReturnDto>();
		}
	}
}
