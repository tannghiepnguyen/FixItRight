namespace FixItRight_Domain.Exceptions
{
	public class NotAuthenticatedException : Exception
	{
		public NotAuthenticatedException() : base()
		{
		}

		public NotAuthenticatedException(string? message) : base(message)
		{
		}

		public NotAuthenticatedException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
