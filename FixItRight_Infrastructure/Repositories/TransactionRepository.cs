using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
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

		public async Task<PagedList<Transaction>> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange)
		{
			var transactions = await FindByCondition(transaction => transaction.UserId.Equals(userId), trackChange).OrderBy(c => c.CreatedAt).ToListAsync();
			return PagedList<Transaction>.ToPagedList(transactions, transactionParameters.PageNumber, transactionParameters.PageSize);
		}

		public async Task<PagedList<Transaction>> GetTransactions(TransactionParameters transactionParameters, bool trackChange)
		{
			var transactions = await FindAll(trackChange).OrderBy(c => c.CreatedAt).ToListAsync();
			return PagedList<Transaction>.ToPagedList(transactions, transactionParameters.PageNumber, transactionParameters.PageSize);
		}

		public async Task<Transaction?> GetTransactionById(Guid id, bool trackChange) => await FindByCondition(transaction => transaction.Id.Equals(id), trackChange).SingleOrDefaultAsync();

		public async Task<Transaction?> GetTransactionById(long code, bool trackChange) => await FindByCondition(transaction => transaction.OrderCode.Equals(code), trackChange).SingleOrDefaultAsync();
	}
}
