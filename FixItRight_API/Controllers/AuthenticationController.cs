using FixItRight_Domain;
using FixItRight_Service.IServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/authentication")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IServiceManager service;

		public AuthenticationController(IServiceManager service)
		{
			this.service = service;
		}

		[HttpPost("customers")]
		public async Task<IActionResult> RegisterCustomer([FromForm] UserForRegistrationDto userForRegistration)
		{
			var result = await service.UserService.RegisterCustomer(userForRegistration);
			if (!result.Succeeded)
			{
				CustomError customError = new CustomError();
				foreach (var error in result.Errors)
				{
					customError.Errors.Add(error.Description);
				}
				return BadRequest(customError);
			}
			return StatusCode(201);
		}

		[HttpPost("mechanists")]
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

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromForm] UserForAuthenticationDto user)
		{
			if (!await service.UserService.ValidateUser(user))
				return Unauthorized();

			var tokenDto = await service.UserService.CreateToken(populateExp: true);
			return Ok(tokenDto);
		}

		[HttpPost("refresh")]
		public async Task<IActionResult> Refresh([FromForm] TokenDto tokenDto)
		{
			var tokenDtoToReturn = await service.UserService.RefreshToken(tokenDto);
			return Ok(tokenDtoToReturn);
		}
	}
}
