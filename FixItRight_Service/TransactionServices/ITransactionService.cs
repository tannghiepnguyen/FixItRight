﻿using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.TransactionServices.DTOs;
using Net.payOS.Types;

namespace FixItRight_Service.TransactionServices
{
	public interface ITransactionService
	{
		Task<string> CreateTransaction(TransactionForCreationDto transaction);
		Task<(IEnumerable<TransactionForReturnDto> transactions, MetaData metaData)> GetTransactionsByUserId(string userId, TransactionParameters transactionParameters, bool trackChange);
		Task<(IEnumerable<TransactionForReturnDto> transactions, MetaData metaData)> GetTransactions(TransactionParameters transactionParameters, bool trackChange);
		Task IPNAsync(WebhookData webhookData);
	}
}
