using FixItRight_Service.ChatServices.DTOs;

namespace FixItRight_Service.ChatServices
{
	public interface IChatService
	{
		Task<IEnumerable<ChatForReturnDto>> GetChatsByBookingId(Guid bookingId, bool trackChange);
		Task CreateChat(ChatForCreationDto chatForCreationDto);
	}
}
