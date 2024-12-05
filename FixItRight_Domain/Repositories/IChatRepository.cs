using FixItRight_Domain.Models;

namespace FixItRight_Domain.Repositories
{
	public interface IChatRepository
	{
		void CreateChat(Chat chat);
		Task<IEnumerable<Chat>> GetChatsByBookingId(Guid bookingId, bool trackChange);

	}
}
