using AutoMapper;
using FixItRight_Domain.Models;

namespace FixItRight_Service.CategoryServices.DTOs
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryForReturnDto>();
			CreateMap<CategoryForCreationDto, Category>();
			CreateMap<CategoryForUpdateDto, Category>();
		}
	}
}
