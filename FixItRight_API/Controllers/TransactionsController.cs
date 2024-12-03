using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public TransactionsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet("{bookingId:guid}")]
		public async Task<IActionResult> GetTransactionByBookingId([FromRoute] Guid bookingId)
		{
			var transaction = await serviceManager.TransactionService.GetTransactionByBookingId(bookingId, false);
			return Ok(transaction);
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetTransactionsByUserId([FromRoute] string userId)
		{
			var transactions = await serviceManager.TransactionService.GetTransactionsByUserId(userId, false);
			return Ok(transactions);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTransactions()
		{
			var transactions = await serviceManager.TransactionService.GetTransactions(false);
			return Ok(transactions);
		}

		[HttpPost]
		public async Task<IActionResult> CreateTransaction([FromForm] TransactionForCreationDto transaction)
		{
			var createdTransaction = await serviceManager.TransactionService.CreateTransaction(transaction);
			return CreatedAtAction(nameof(GetTransactionByBookingId), new { bookingId = createdTransaction.BookingId }, createdTransaction);
		}



	}
}
