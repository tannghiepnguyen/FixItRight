﻿using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Identity;

namespace FixItRight_Service.UserServices
{
	public interface IUserService
	{
		Task<IdentityResult> RegisterCustomer(UserForRegistrationDto userForRegistration);
		Task<IdentityResult> RegisterMechanist(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
		Task<string> CreateToken();
	}
}
