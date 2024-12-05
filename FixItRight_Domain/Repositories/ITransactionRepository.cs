using FixItRight_Domain.Models;

namespace FixItRight_Domain.Repositories
{
	public interface ITransactionRepository
	{
		Task<Transaction?> GetTransactionByBookingId(Guid bookingId, bool trackChange);
		Task<Transaction?> GetTransactionById(Guid id, bool trackChange);
		Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId, bool trackChange);
		Task<IEnumerable<Transaction>> GetTransactions(bool trackChange);
		void CreateTransaction(Transaction transaction);

	}
}
