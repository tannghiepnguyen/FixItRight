using FixItRight_Domain;
using FixItRight_Domain.Constants;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.TransactionServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;
using System.Text.Json;

namespace FixItRight_API.Controllers
{
	[Route("api/transactions")]
	[ApiController]
	public class TransactionsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;
		private readonly HttpClient httpClient;
		private readonly IConfiguration configuration;

		public TransactionsController(IServiceManager serviceManager, HttpClient httpClient, IConfiguration configuration)
		{
			this.serviceManager = serviceManager;
			this.httpClient = httpClient;
			this.configuration = configuration;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> CreateTransaction([FromBody] TransactionForCreationDto transaction)
		{
			await serviceManager.TransactionService.CreateTransaction(transaction);
			return StatusCode(201);
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

		//[HttpPost]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[Authorize(Roles = $"{nameof(Role.Customer)}")]
		//public async Task<IActionResult> CreateTransaction([FromBody] TransactionForCreationDto transaction)
		//{
		//	var paymentUrl = await serviceManager.TransactionService.CreateTransaction(transaction);
		//	return Ok(new { data = paymentUrl });
		//}
		public record Responses(int error, String message, object? data);

		[HttpPost("receive-hook")]
		public async Task<IActionResult> IPN([FromBody] WebhookType webhookBody)
		{
			var clientId = configuration.GetSection("PayOSClientID").Value;
			var apiKey = configuration.GetSection("PayOSAPIKey").Value;
			var checksumKey = configuration.GetSection("PayOSChecksumKey").Value;

			var payOS = new PayOS(clientId, apiKey, checksumKey);
			WebhookData data = payOS.verifyPaymentWebhookData(webhookBody);

			await serviceManager.TransactionService.IPNAsync(data);
			return Ok(new Responses(0, "Success", null));
		}

		[HttpGet("total-transactions")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetTotalTransactions()
		{
			var totalTransaction = await serviceManager.TransactionService.GetNumberOfTransactions();
			return Ok(new
			{
				data = totalTransaction
			});
		}

		[HttpGet("total-money")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetTotalMoney()
		{
			var totalTransaction = await serviceManager.TransactionService.GetTotalMoney();
			return Ok(new
			{
				data = totalTransaction
			});
		}
	}
}
