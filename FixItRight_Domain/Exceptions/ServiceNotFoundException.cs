namespace FixItRight_Domain.Exceptions
{
	public class ServiceNotFoundException : NotFoundException
	{
		public ServiceNotFoundException(Guid id) : base($"The service with id: {id} doesn't exist")
		{
		}
	}
}
