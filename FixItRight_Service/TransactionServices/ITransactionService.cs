using FixItRight_Service.TransactionServices.DTOs;

namespace FixItRight_Service.TransactionServices
{
	public interface ITransactionService
	{
		Task<TransactionForReturnDto?> GetTransactionByBookingId(Guid bookingId, bool trackChange);
		Task<TransactionForReturnDto> CreateTransaction(TransactionForCreationDto transaction);
		Task<IEnumerable<TransactionForReturnDto>> GetTransactionsByUserId(string userId, bool trackChange);
		Task<IEnumerable<TransactionForReturnDto>> GetTransactions(bool trackChange);
	}
}
