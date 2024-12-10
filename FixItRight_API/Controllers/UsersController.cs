using FixItRight_Domain;
using FixItRight_Domain.Constants;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FixItRight_API.Controllers
{
	[Route("api/users")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IServiceManager service;

		public UsersController(IServiceManager service)
		{
			this.service = service;
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<IActionResult> GetUserById(string id)
		{
			var user = await service.UserService.GetUserById(id);
			return Ok(new
			{
				data = user
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
		{
			var pagedResult = await service.UserService.GetUsers(userParameters);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<UserForReturnDto>()
				{
					Data = pagedResult.users,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpPut("{id}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[Authorize]
		public async Task<IActionResult> UpdateUser(string id, UserForUpdateDto userForUpdate)
		{
			var user = await service.UserService.UpdateUser(id, userForUpdate);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize]
		public async Task<IActionResult> DeleteUser(string id)
		{
			await service.UserService.DeleteUser(id);
			return NoContent();
		}

		[HttpPut("{id}/verify")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> VerifyUser(string id)
		{
			await service.UserService.VerifyUser(id);
			return NoContent();
		}

	}
}
