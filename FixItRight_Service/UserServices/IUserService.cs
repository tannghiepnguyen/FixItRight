using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Identity;

namespace FixItRight_Service.UserServices
{
	public interface IUserService
	{
		Task<IdentityResult> RegisterCustomer(UserForRegistrationDto userForRegistration);
		Task<IdentityResult> RegisterMechanist(UserForRegistrationDto userForRegistration);
		Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
		Task<TokenDto> CreateToken(bool populateExp);
		Task<TokenDto> RefreshToken(TokenDto tokenDto);
		Task<UserForReturnDto> GetUserById(string userId);
	}
}
