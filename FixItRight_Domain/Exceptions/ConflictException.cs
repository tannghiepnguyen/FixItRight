namespace FixItRight_Domain.Exceptions
{
	public abstract class ConflictException : Exception
	{
		public ConflictException(string? message) : base(message)
		{
		}
	}
}
