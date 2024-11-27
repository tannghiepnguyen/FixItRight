using FixItRight_Service.IServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IServiceManager service;

		public AuthenticationController(IServiceManager service)
		{
			this.service = service;
		}

		[HttpPost("customer")]
		public async Task<IActionResult> RegisterCustomer([FromForm] UserForRegistrationDto userForRegistration)
		{
			var result = await service.UserService.RegisterCustomer(userForRegistration);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}
			return StatusCode(201);
		}

		[HttpPost("mechanist")]
		public async Task<IActionResult> RegisterMechanist([FromForm] UserForRegistrationDto userForRegistration)
		{
			var result = await service.UserService.RegisterMechanist(userForRegistration);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.TryAddModelError(error.Code, error.Description);
				}
				return BadRequest(ModelState);
			}
			return StatusCode(201);
		}
	}
}
