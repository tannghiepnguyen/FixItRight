using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Service.IServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FixItRight_Service.UserServices
{
	internal sealed class UserService : IUserService
	{
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;
		private readonly UserManager<User> userManager;
		private readonly IConfiguration configuration;
		private User? user;

		public UserService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
		{
			this.logger = logger;
			this.mapper = mapper;
			this.userManager = userManager;
			this.configuration = configuration;
		}
		public async Task<IdentityResult> RegisterCustomer(UserForRegistrationDto userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.CreatedAt = DateTime.Now;
			user.Active = true;
			user.IsVerified = false;
			user.Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=";
			var result = await userManager.CreateAsync(user, userForRegistration.Password!);
			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Role.Customer);
			}
			return result;
		}

		public async Task<IdentityResult> RegisterMechanist(UserForRegistrationDto userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.CreatedAt = DateTime.Now;
			user.Active = true;
			user.IsVerified = false;
			user.Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=";
			var result = await userManager.CreateAsync(user, userForRegistration.Password!);
			if (result.Succeeded)
				await userManager.AddToRoleAsync(user, Role.Mechanist);
			return result;
		}

		public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
		{
			user = await userManager.FindByNameAsync(userForAuth.UserName!);
			var result = (user != null && await userManager.CheckPasswordAsync(user, userForAuth.Password!) && user.Active);
			if (!result)
				logger.LogWarning($"{nameof(ValidateUser)}: " +
					$"Authentication failed. Wrong user name or password.");
			return result;
		}
		public async Task<TokenDto> CreateToken(bool populateExp)
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims();
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

			var refreshToken = GenerateRefreshToken();

			user.RefreshToken = refreshToken;

			if (populateExp)
				user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

			await userManager.UpdateAsync(user);

			var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

			return new TokenDto
			{
				AccessToken = accessToken,
				RefreshToken = refreshToken
			};
		}
		private SigningCredentials GetSigningCredentials()
		{
			var jwtSettings = configuration.GetSection("JwtSettings");
			var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]!);
			var secret = new SymmetricSecurityKey(key);
			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}
		private async Task<List<Claim>> GetClaims()
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user!.UserName!)
			};
			claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
			claims.Add(new Claim("Fullname", user.Fullname));
			var roles = await userManager.GetRolesAsync(user);
			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}
			return claims;
		}
		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials,
			List<Claim> claims)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");
			var tokenOptions = new JwtSecurityToken
			(
				issuer: jwtSettings["validIssuer"],
				audience: jwtSettings["validAudience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
				signingCredentials: signingCredentials
			);
			return tokenOptions;
		}

		private string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				return Convert.ToBase64String(randomNumber);
			}
		}

		private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			var jwtSettings = configuration.GetSection("JwtSettings");

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateAudience = true,
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(jwtSettings["secretKey"])),
				ValidateLifetime = true,
				ValidIssuer = jwtSettings["validIssuer"],
				ValidAudience = jwtSettings["validAudience"]
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			SecurityToken securityToken;
			var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

			var jwtSecurityToken = securityToken as JwtSecurityToken;
			if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
				StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}

			return principal;
		}

		public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
		{
			var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
			var currentUser = await userManager.FindByNameAsync(principal.Identity.Name);
			if (currentUser == null || currentUser.RefreshToken != tokenDto.RefreshToken || currentUser.RefreshTokenExpiryTime <= DateTime.Now)
			{
				throw new RequestTokenBadRequest();
			}
			user = currentUser;
			return await CreateToken(populateExp: false);
		}

		public async Task<UserForReturnDto> GetUserById(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			if (user is null) throw new UserNotFoundException(userId);

			var returnUser = mapper.Map<UserForReturnDto>(user);
			returnUser.Roles = userManager.GetRolesAsync(user).Result.ToList();

			return returnUser;
		}
	}
}
