using FixItRight_Domain.Constants;
using FixItRight_Service.CategoryServices.DTOs;
using FixItRight_Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/categories")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public CategoriesController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<IActionResult> GetCategoriesAsync()
		{
			var categories = await serviceManager.CategoryService.GetCategoriesAsync(false);
			return Ok(new
			{
				data = categories
			});
		}
		[HttpGet("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<IActionResult> GetCategoryById([FromRoute] Guid id)
		{
			var category = await serviceManager.CategoryService.GetCategoryByIdAsync(id, false);
			return Ok(new
			{
				data = category
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> AddCategoryAsync([FromForm] CategoryForCreationDto categoryForCreation)
		{
			var category = await serviceManager.CategoryService.AddCategoryAsync(categoryForCreation);
			return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
		}

		[HttpPut("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> UpdateCategoryAsync([FromRoute] Guid id, [FromForm] CategoryForUpdateDto categoryForUpdate)
		{
			await serviceManager.CategoryService.UpdateCategoryAsync(id, categoryForUpdate, true);
			return NoContent();
		}
	}
}
