using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class ChatRepository : RepositoryBase<Chat>, IChatRepository
	{
		public ChatRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateChat(Chat chat) => Create(chat);

		public async Task<IEnumerable<Chat>> GetChatsByBookingId(Guid bookingId, bool trackChange) => await FindByCondition(c => c.BookingId.Equals(bookingId), trackChange).ToListAsync();
	}
}
