using FixItRight_Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace FixItRight_Domain.Models
{
	public class User : IdentityUser
	{
		public string? Fullname { get; set; }
		public bool Active { get; set; }
		public string? Avatar { get; set; }
		public Gender? Gender { get; set; }
		public DateOnly? Birthday { get; set; }
		public bool IsVerified { get; set; }
		public string? CccdFront { get; set; }
		public string? CccdBack { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public string? PasswordResetToken { get; set; }
		public DateTime? PasswordResetTokenExpiryTime { get; set; }
		public string? RefreshToken { get; set; }
		public DateTime? RefreshTokenExpiryTime { get; set; }
		public string? Address { get; set; }
		public double Balance { get; set; }
		public ICollection<Chat> Chats { get; set; }
		public ICollection<Booking> CustomerBookings { get; set; }
		public ICollection<Booking> MechanistBookings { get; set; }
		public ICollection<Transaction> Transactions { get; set; }
	}
}
