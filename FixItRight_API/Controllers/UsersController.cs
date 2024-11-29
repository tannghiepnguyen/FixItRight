using FixItRight_Service.IServices;
using Microsoft.AspNetCore.Mvc;

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
		public async Task<IActionResult> GetUserById(string id)
		{
			var user = await service.UserService.GetUserById(id);
			return Ok(user);
		}
	}
}
