using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
	{
		public TransactionRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateTransaction(Transaction transaction) => Create(transaction);

		public async Task<Transaction?> GetTransactionByBookingId(Guid bookingId, bool trackChange) => await FindByCondition(transaction => transaction.BookingId.Equals(bookingId), trackChange).SingleOrDefaultAsync();

		public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId, bool trackChange) => await FindByCondition(transaction => transaction.UserId.Equals(userId), trackChange).ToListAsync();

		public async Task<IEnumerable<Transaction>> GetTransactions(bool trackChange) => await FindAll(trackChange).ToListAsync();
	}
}
