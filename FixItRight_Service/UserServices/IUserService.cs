using FixItRight_Domain.RequestFeatures;
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
		Task<UserForReturnDto> GetUserByToken(string token);
		Task<(IEnumerable<UserForReturnDto> users, MetaData metaData)> GetUsers(UserParameters userParameters);
		Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdate);
		Task<IdentityResult> DeactivateUser(string userId);
		Task<IdentityResult> VerifyUser(string userId);
		Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto);
		Task<IdentityResult> ConfirmEmail(string token, string email);
		Task SendResetPasswordToken(string email, CancellationToken ct = default);
		Task ResetPassword(UserForResetPasswordDto userForResetPasswordDto, CancellationToken ct = default);
		Task<string> Deposit(UserForDepositDto userForDepositDto, CancellationToken ct = default);
	}
}
