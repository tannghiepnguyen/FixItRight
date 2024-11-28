namespace FixItRight_Domain.Exceptions
{
	public abstract class NotFoundException : Exception
	{

		public NotFoundException(string? message) : base(message)
		{
		}
	}
}
