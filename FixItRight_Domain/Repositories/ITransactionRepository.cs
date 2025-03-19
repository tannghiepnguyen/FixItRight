using FixItRight_Domain.Models;
using FixItRight_Domain.RequestFeatures;

namespace FixItRight_Domain.Repositories
{
	public interface ITransactionRepository
	{
		Task<Transaction?> GetTransactionById(Guid id, bool trackChange);
		Task<Transaction?> GetTransactionById(long code, bool trackChange);
		Task<PagedList<Transaction>> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange);
		Task<PagedList<Transaction>> GetTransactions(TransactionParameters transactionParameters, bool trackChange);
		IQueryable<Transaction> GetTransactions(bool trackChange);
		void CreateTransaction(Transaction transaction);

	}
}
