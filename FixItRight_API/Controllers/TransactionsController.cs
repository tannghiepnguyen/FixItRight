using FixItRight_Domain;
using FixItRight_Domain.Constants;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FixItRight_API.Controllers
{
	[Route("api/transactions")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public TransactionsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet("{bookingId:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<IActionResult> GetTransactionByBookingId([FromRoute] Guid bookingId)
		{
			var transaction = await serviceManager.TransactionService.GetTransactionByBookingId(bookingId, false);
			return Ok(new
			{
				data = transaction
			});
		}

		[HttpPost("{userId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> GetTransactionsByUserId([FromRoute] string userId, [FromQuery] TransactionParameters transactionParameters)
		{
			var pagedResult = await serviceManager.TransactionService.GetTransactionsByUserId(userId, transactionParameters, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<TransactionForReturnDto>()
				{
					Data = pagedResult.transactions,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpPost("get-transactions")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetAllTransactions([FromQuery] TransactionParameters transactionParameters)
		{
			var pagedResult = await serviceManager.TransactionService.GetTransactions(transactionParameters, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<TransactionForReturnDto>()
				{
					Data = pagedResult.transactions,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> CreateTransaction([FromForm] TransactionForCreationDto transaction)
		{
			var paymentUrl = await serviceManager.TransactionService.CreateTransaction(transaction);
			return Ok(new { data = paymentUrl });
		}

		[HttpGet("ipn")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> IPN()
		{
			var result = await serviceManager.TransactionService.IPNAsync(Request.Query);
			return Ok(result);
		}

	}
}
