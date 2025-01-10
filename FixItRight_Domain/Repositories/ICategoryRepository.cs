using FixItRight_Domain.Models;

namespace FixItRight_Domain.Repositories
{
	public interface ICategoryRepository
	{
		public Task<IEnumerable<Category>> GetCategories(bool trackChange);
		public Task<Category?> GetCategoryById(Guid categoryId, bool trackChange);
		public void CreateCategory(Category category);
	}
}
