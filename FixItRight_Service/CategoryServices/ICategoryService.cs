using FixItRight_Service.CategoryServices.DTOs;

namespace FixItRight_Service.CategoryServices
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryForReturnDto>> GetCategoriesAsync(bool trackChange);
		Task<CategoryForReturnDto?> GetCategoryByIdAsync(Guid id, bool trackChange);
		Task<CategoryForReturnDto> AddCategoryAsync(CategoryForCreationDto category);
		Task UpdateCategoryAsync(Guid id, CategoryForUpdateDto category, bool trackChange);
	}
}
