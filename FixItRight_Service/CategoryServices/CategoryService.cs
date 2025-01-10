using AutoMapper;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.CategoryServices.DTOs;
using FixItRight_Service.IServices;

namespace FixItRight_Service.CategoryServices
{
	internal sealed class CategoryService : ICategoryService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;

		public CategoryService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
		}
		private async Task<Category> CheckCategoryExist(Guid id, bool trackChange)
		{
			var category = await repositoryManager.CategoryRepository.GetCategoryById(id, trackChange);
			return category ?? throw new CategoryNotFoundException(id);
		}
		public async Task<CategoryForReturnDto> AddCategoryAsync(CategoryForCreationDto category)
		{
			var categoryEntity = mapper.Map<Category>(category);
			repositoryManager.CategoryRepository.CreateCategory(categoryEntity);
			await repositoryManager.SaveAsync();
			return mapper.Map<CategoryForReturnDto>(categoryEntity);
		}

		public async Task<IEnumerable<CategoryForReturnDto>> GetCategoriesAsync(bool trackChange)
		{
			var servicesEntity = await repositoryManager.CategoryRepository.GetCategories(trackChange);
			return mapper.Map<IEnumerable<CategoryForReturnDto>>(servicesEntity);
		}

		public async Task<CategoryForReturnDto?> GetCategoryByIdAsync(Guid id, bool trackChange)
		{
			var serviceEntity = await CheckCategoryExist(id, trackChange);
			return mapper.Map<CategoryForReturnDto>(serviceEntity);
		}

		public async Task UpdateCategoryAsync(Guid id, CategoryForUpdateDto category, bool trackChange)
		{
			var categoryEntity = await CheckCategoryExist(id, trackChange);
			mapper.Map(category, categoryEntity);
			await repositoryManager.SaveAsync();
		}
	}
}
