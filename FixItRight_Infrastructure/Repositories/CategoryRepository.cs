using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateCategory(Category category) => Create(category);

		public void DeleteCategory(Category category) => Delete(category);

		public async Task<IEnumerable<Category>> GetCategories(bool trackChange) => await FindAll(trackChange).ToListAsync();

		public async Task<Category?> GetCategoryById(Guid categoryId, bool trackChange) => await FindByCondition(category => category.Id.Equals(categoryId), trackChange).SingleOrDefaultAsync();
	}
}
