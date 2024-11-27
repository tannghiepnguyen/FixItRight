using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Models;
using FixItRight_Service.IServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
				await userManager.AddToRoleAsync(user, Role.Customer);
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
			var result = (user != null && await userManager
				.CheckPasswordAsync(user, userForAuth.Password!));
			if (!result)
				logger.LogWarning($"{nameof(ValidateUser)}: " +
					$"Authentication failed. Wrong user name or password.");
			return result;
		}
		public async Task<string> CreateToken()
		{
			var signingCredentials = GetSigningCredentials();
			var claims = await GetClaims();
			var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
			return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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
	}
}
