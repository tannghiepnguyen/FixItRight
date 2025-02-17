﻿using FixItRight_Domain;
using FixItRight_Service.IServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/authentications")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IServiceManager service;

		public AuthenticationController(IServiceManager service)
		{
			this.service = service;
		}

		[HttpPost("customers")]
		public async Task<IActionResult> RegisterCustomer([FromBody] UserForRegistrationDto userForRegistration)
		{
			var result = await service.UserService.RegisterCustomer(userForRegistration);
			if (!result.Succeeded)
			{
				CustomError customError = new CustomError();
				foreach (var error in result.Errors)
				{
					customError.Errors.Add(error);
				}
				customError.Message = "Registration failed";
				return BadRequest(customError);
			}
			return StatusCode(201);
		}

		[HttpPost("mechanists")]
		public async Task<IActionResult> RegisterMechanist([FromBody] UserForRegistrationDto userForRegistration)
		{
			var result = await service.UserService.RegisterMechanist(userForRegistration);
			if (!result.Succeeded)
			{
				CustomError customError = new CustomError();
				foreach (var error in result.Errors)
				{
					customError.Errors.Add(error);
				}
				customError.Message = "Registration failed";
				return BadRequest(customError);
			}
			return StatusCode(201);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
		{
			if (!await service.UserService.ValidateUser(user))
				return Unauthorized();

			var tokenDto = await service.UserService.CreateToken(populateExp: true);
			return Ok(new
			{
				data = tokenDto
			});
		}

		[HttpPost("refresh")]
		[Authorize]
		public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
		{
			var tokenDtoToReturn = await service.UserService.RefreshToken(tokenDto);
			return Ok(new
			{
				data = tokenDtoToReturn
			});
		}

		[HttpGet("current-user")]
		[Authorize]
		public async Task<IActionResult> GetUserByToken()
		{
			var token = HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
			var user = await service.UserService.GetUserByToken(token);
			return Ok(new
			{
				data = user
			});
		}

		[HttpGet("email-verification")]
		public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string email)
		{
			var result = await service.UserService.ConfirmEmail(token, email);
			if (!result.Succeeded)
			{
				CustomError customError = new CustomError();
				foreach (var error in result.Errors)
				{
					customError.Errors.Add(error);
				}
				customError.Message = "Email verification failed";
				return BadRequest(customError);
			}
			return Redirect("https://fix-it-right.vercel.app/verify");
		}

		[HttpPost("password-forgeting")]
		public async Task<IActionResult> SendResetPasswordToken([FromBody] string email, CancellationToken ct)
		{
			await service.UserService.SendResetPasswordToken(email, ct);
			return Ok("The OTP has been sent to your email");
		}

		[HttpPut("password-forgeting")]
		public async Task<IActionResult> ResetPassword([FromBody] UserForResetPasswordDto userForResetPasswordDto, CancellationToken ct)
		{
			await service.UserService.ResetPassword(userForResetPasswordDto, ct);
			return Ok();
		}
	}
}
