namespace FixItRight_Domain.Exceptions
{
	public class NotEnoughMoneyException : Exception
	{
		public NotEnoughMoneyException() : base()
		{
		}

		public NotEnoughMoneyException(string? message) : base(message)
		{
		}

		public NotEnoughMoneyException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
