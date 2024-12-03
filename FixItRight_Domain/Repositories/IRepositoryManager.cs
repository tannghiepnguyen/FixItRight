﻿namespace FixItRight_Domain.Repositories
{
	public interface IRepositoryManager
	{
		IRepairServiceRepository RepairService { get; }
		IRatingRepository RatingRepository { get; }
		IBookingRepository BookingRepository { get; }
		ITransactionRepository TransactionRepository { get; }
		Task SaveAsync();
	}
}
