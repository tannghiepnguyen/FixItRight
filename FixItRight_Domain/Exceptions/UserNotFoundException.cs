namespace FixItRight_Domain.Exceptions
{
	public sealed class UserNotFoundException : NotFoundException
	{

		public UserNotFoundException(string userId) : base($"The user with id: {userId} doesn't exist")
		{
		}
	}
}
