using AutoMapper;
using FixItRight_Domain.Constants;
using FixItRight_Domain.Exceptions;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.EmailServices;
using FixItRight_Service.EmailServices.DTOs;
using FixItRight_Service.IServices;
using FixItRight_Service.Jobs;
using FixItRight_Service.TransactionServices;
using FixItRight_Service.UserServices.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Net.payOS;
using Net.payOS.Types;
using Quartz;
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
		private readonly IBlobService blobService;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IEmailSender emailSender;
		private readonly ISchedulerFactory schedulerFactory;
		private readonly Utils utils;
		private readonly IRepositoryManager repositoryManager;
		private User? user;

		public UserService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IBlobService blobService, IHttpContextAccessor httpContextAccessor, IEmailSender emailSender, ISchedulerFactory schedulerFactory, Utils utils, IRepositoryManager repositoryManager)
		{
			this.logger = logger;
			this.mapper = mapper;
			this.userManager = userManager;
			this.configuration = configuration;
			this.blobService = blobService;
			this.httpContextAccessor = httpContextAccessor;
			this.emailSender = emailSender;
			this.schedulerFactory = schedulerFactory;
			this.utils = utils;
			this.repositoryManager = repositoryManager;
		}
		public async Task<IdentityResult> RegisterCustomer(UserForRegistrationDto userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.CreatedAt = DateTime.Now;
			user.Active = true;
			user.Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=";
			user.CccdBack = string.Empty;
			user.CccdFront = string.Empty;
			user.Balance = 0;
			var result = await userManager.CreateAsync(user, userForRegistration.Password!);
			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(user, Role.Customer.ToString());
			}

			var param = new Dictionary<string, string>
			{
				{ "token", await userManager.GenerateEmailConfirmationTokenAsync(user) },
				{ "email", user.Email }
			};
			var request = httpContextAccessor.HttpContext?.Request;
			var uri = $"{request?.Scheme}://{request?.Host}/api/authentications/email-verification";
			var callback = QueryHelpers.AddQueryString(uri, param);
			IJobDetail job = JobBuilder.Create<EmailSendingJob>()
			.WithIdentity("emailJob", "group1")
			.UsingJobData("to", user.Email)
			.UsingJobData("subject", "Email verification")
			.UsingJobData("body", $"<p>Please click <a href='{callback}'>here</a> to verify your email</p>")
			.Build();

			ITrigger trigger = TriggerBuilder.Create()
		   .WithIdentity("emailTrigger", "group1")
		   .StartNow()
		   .Build();

			var scheduler = await schedulerFactory.GetScheduler();

			await scheduler.ScheduleJob(job, trigger);
			return result;
		}

		public async Task<IdentityResult> RegisterMechanist(UserForRegistrationDto userForRegistration)
		{
			var user = mapper.Map<User>(userForRegistration);
			user.CreatedAt = DateTime.Now;
			user.Active = true;
			user.Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=";
			user.CccdBack = string.Empty;
			user.CccdFront = string.Empty;
			user.Balance = 0;
			var result = await userManager.CreateAsync(user, userForRegistration.Password!);
			if (result.Succeeded)
				await userManager.AddToRoleAsync(user, Role.Mechanist.ToString());

			var param = new Dictionary<string, string>
			{
				{ "token", await userManager.GenerateEmailConfirmationTokenAsync(user) },
				{ "email", user.Email }
			};
			var request = httpContextAccessor.HttpContext?.Request;
			var uri = $"{request?.Scheme}://{request?.Host}/api/authentications/email-verification";
			var callback = QueryHelpers.AddQueryString(uri, param);
			IJobDetail job = JobBuilder.Create<EmailSendingJob>()
			.WithIdentity("emailJob", "group1")
			.UsingJobData("to", user.Email)
			.UsingJobData("subject", "Email verification")
			.UsingJobData("body", $"<p>Please click <a href='{callback}'>here</a> to verify your email</p>")
			.Build();

			ITrigger trigger = TriggerBuilder.Create()
		   .WithIdentity("emailTrigger", "group1")
		   .StartNow()
		   .Build();

			var scheduler = await schedulerFactory.GetScheduler();

			await scheduler.ScheduleJob(job, trigger);
			return result;
		}

		public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
		{
			user = await userManager.FindByNameAsync(userForAuth.UserName!);
			if (user is null || !(await userManager.CheckPasswordAsync(user, userForAuth.Password!)))
			{
				throw new NotAuthenticatedException("Username or password is incorrect");
			}
			if (!user.Active)
			{
				throw new NotAuthenticatedException("User is deactivated");
			}
			//if (!user.EmailConfirmed)
			//{
			//	throw new NotAuthenticatedException("Email is not verified");
			//}
			var result = (user != null && await userManager.CheckPasswordAsync(user, userForAuth.Password!) && user.Active);
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

		private string GenerateOTP()
		{
			Random random = new Random();
			int otp = random.Next(100000, 999999);
			return otp.ToString();
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

		public Task<UserForReturnDto> GetUserByToken(string jwt)
		{
			var handler = new JwtSecurityTokenHandler();
			var token = handler.ReadJwtToken(jwt);
			var userId = token.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
			return GetUserById(userId);
		}

		public async Task<(IEnumerable<UserForReturnDto> users, MetaData metaData)> GetUsers(UserParameters userParameters)
		{
			var users = userManager.Users;
			var returnUsers = mapper.Map<IEnumerable<UserForReturnDto>>(users);
			foreach (var user in returnUsers)
			{
				user.Roles = await userManager.GetRolesAsync(users.First(u => u.Id == user.Id));
			}
			//returnUsers = returnUsers.Where(u => !u.Roles.Contains(Role.Admin.ToString()));
			if (!string.IsNullOrWhiteSpace(userParameters.Role.ToString()))
			{
				returnUsers = returnUsers.Where(u => u.Roles.Contains(userParameters.Role.ToString()));
			}
			if (!string.IsNullOrWhiteSpace(userParameters.SearchName))
			{
				returnUsers = returnUsers.Where(u => u.Fullname.ToLower().Contains(userParameters.SearchName.ToLower()));
			}
			returnUsers = returnUsers.Where(u => u.Active == userParameters.Active);
			returnUsers = returnUsers.Where(u => u.IsVerified == userParameters.IsVerified);
			var usersWithMetaData = PagedList<UserForReturnDto>.ToPagedList(returnUsers, userParameters.PageNumber, userParameters.PageSize);
			return (usersWithMetaData, usersWithMetaData.MetaData);

		}

		public async Task<IdentityResult> UpdateUser(string userId, UserForUpdateDto userForUpdate)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			mapper.Map(userForUpdate, user);
			user.UpdatedAt = DateTime.Now;

			return await userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> DeactivateUser(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			user.Active = false;

			return await userManager.UpdateAsync(user);
		}



		public async Task<IdentityResult> UpdateUserPassword(string userId, UserForUpdatePasswordDto userForUpdatePasswordDto)
		{
			var user = await userManager.FindByIdAsync(userId);

			if (user is null) throw new UserNotFoundException(userId);

			return await userManager.ChangePasswordAsync(user, userForUpdatePasswordDto.OldPassword, userForUpdatePasswordDto.NewPassword);
		}

		public async Task<IdentityResult> ConfirmEmail(string token, string email)
		{
			var user = await userManager.FindByEmailAsync(email);
			return await userManager.ConfirmEmailAsync(user, token);
		}

		public async Task SendResetPasswordToken(string email, CancellationToken ct = default)
		{
			var userEntity = await userManager.FindByEmailAsync(email);
			if (userEntity is null) throw new UserNotFoundException(userEntity.Id);

			userEntity.PasswordResetToken = GenerateOTP();
			userEntity.PasswordResetTokenExpiryTime = DateTime.Now.AddHours(1);

			await userManager.UpdateAsync(userEntity);

			var mail = new Mail(userEntity.Email, "Reset password OTP", $"<p>Your reset password OTP is: <i>{userEntity.PasswordResetToken}</i></p>");
			emailSender.SendEmail(mail);

			IJobDetail job = JobBuilder.Create<EmailSendingJob>()
			.WithIdentity("emailJob", "group1")
			.UsingJobData("to", userEntity.Email)
			.UsingJobData("subject", "Reset password OTP")
			.UsingJobData("body", $"<p>Your reset password OTP is: <i>{userEntity.PasswordResetToken}</i></p>")
			.Build();

			ITrigger trigger = TriggerBuilder.Create()
		   .WithIdentity("emailTrigger", "group1")
		   .StartNow()
		   .Build();

			var scheduler = await schedulerFactory.GetScheduler(ct);

			await scheduler.ScheduleJob(job, trigger, ct);
		}

		public async Task ResetPassword(UserForResetPasswordDto userForResetPasswordDto, CancellationToken ct = default)
		{
			var userEntity = await userManager.FindByEmailAsync(userForResetPasswordDto.Email);
			if (userEntity is null || userEntity.PasswordResetToken != userForResetPasswordDto.Token || userEntity.PasswordResetTokenExpiryTime <= DateTime.Now)
			{
				throw new RequestTokenBadRequest();
			}

			userEntity.PasswordHash = new PasswordHasher<User>().HashPassword(userEntity, userForResetPasswordDto.Password);
			userEntity.PasswordResetToken = null;
			userEntity.PasswordResetTokenExpiryTime = null;
			await userManager.UpdateAsync(userEntity);
		}

		public async Task<string> Deposit(UserForDepositDto userForDepositDto, CancellationToken ct = default)
		{
			var transaction = new FixItRight_Domain.Models.Transaction
			{
				Id = Guid.NewGuid(),
				Amount = userForDepositDto.Amount,
				OrderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff")),
				CreatedAt = DateTime.Now,
				Status = TransactionStatus.Pending,
				UserId = userForDepositDto.UserId
			};
			repositoryManager.TransactionRepository.CreateTransaction(transaction);

			await repositoryManager.SaveAsync();

			//var vnpay = new VnPayLibrary();
			//vnpay.AddRequestData("vnp_Version", "2.1.0");
			//vnpay.AddRequestData("vnp_Command", "pay");
			//vnpay.AddRequestData("vnp_TmnCode", configuration.GetSection("VNPay").GetSection("TmnCode").Value);
			//vnpay.AddRequestData("vnp_Amount", (transaction.Amount * 100).ToString());
			//vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
			//vnpay.AddRequestData("vnp_CurrCode", "VND");
			//vnpay.AddRequestData("vnp_IpAddr", utils.GetIpAddress());
			//vnpay.AddRequestData("vnp_Locale", "vn");
			//vnpay.AddRequestData("vnp_OrderType", "other");
			//vnpay.AddRequestData("vnp_OrderInfo", $"Payment for order {transaction.Id}");
			//vnpay.AddRequestData("vnp_ReturnUrl", configuration.GetSection("VNPay").GetSection("ReturnUrlMobile").Value);
			//vnpay.AddRequestData("vnp_TxnRef", transaction.Id.ToString());
			//var paymentUrl = vnpay.CreateRequestUrl(configuration.GetSection("VNPay").GetSection("Url").Value, configuration.GetSection("VNPay").GetSection("HashSecret").Value);

			//return paymentUrl;

			var clientId = configuration.GetSection("PayOSClientID").Value;
			var apiKey = configuration.GetSection("PayOSAPIKey").Value;
			var checksumKey = configuration.GetSection("PayOSChecksumKey").Value;

			var domain = "https://fix-it-right.vercel.app/login";

			var payOS = new PayOS(clientId, apiKey, checksumKey);

			var paymentLinkRequest = new PaymentData(
				orderCode: transaction.OrderCode,
				amount: (int)transaction.Amount,
				description: "Payment",
				items: [new("Deposit", 1, (int)transaction.Amount)],
				returnUrl: domain + "?success=true",
				cancelUrl: domain + "?canceled=true"
			);
			var response = await payOS.createPaymentLink(paymentLinkRequest);

			return response.checkoutUrl;
		}

		public int GetnumberOfUsers(CancellationToken ct = default)
		{
			var users = userManager.Users;
			return users.Count();
		}
	}
}
