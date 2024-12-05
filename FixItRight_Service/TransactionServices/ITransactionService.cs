using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_Service.TransactionServices
{
	public interface ITransactionService
	{
		Task<TransactionForReturnDto?> GetTransactionByBookingId(Guid bookingId, bool trackChange);
		Task<string> CreateTransaction(TransactionForCreationDto transaction);
		Task<IEnumerable<TransactionForReturnDto>> GetTransactionsByUserId(string userId, bool trackChange);
		Task<IEnumerable<TransactionForReturnDto>> GetTransactions(bool trackChange);
		Task<IActionResult> IPNAsync(IQueryCollection query);
	}
}
