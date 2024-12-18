﻿using FixItRight_Domain.Constants;

namespace FixItRight_Domain.Models
{
	public class Transaction
	{
		public Guid Id { get; set; }
		public double Amount { get; set; }
		public DateTime CreatedAt { get; set; }
		public TransactionStatus Status { get; set; }
		public Guid BookingId { get; set; }
		public Booking Booking { get; set; }
		public string UserId { get; set; }
		public User User { get; set; }
	}
}
