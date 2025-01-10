namespace FixItRight_Domain.Exceptions
{
	public class CategoryNotFoundException : NotFoundException
	{
		public CategoryNotFoundException(Guid categoryId) : base($"The category with id: {categoryId} doesn't exist")
		{
		}
	}
}
