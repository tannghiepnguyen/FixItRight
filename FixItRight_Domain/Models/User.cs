using FixItRight_Domain.Constants;
using Microsoft.AspNetCore.Identity;

namespace FixItRight_Domain.Models
{
	public class User : IdentityUser
	{
		public string Fullname { get; set; }
		public bool Active { get; set; }
		public string? Avatar { get; set; }
		public Gender Gender { get; set; }
		public DateOnly Birthday { get; set; }
		public bool IsVerified { get; set; }
		public string? CccdFront { get; set; }
		public string? CccdBack { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ICollection<Chat> CustomerChats { get; set; }
		public ICollection<Chat> MechanistChats { get; set; }
		public ICollection<Booking> CustomerBookings { get; set; }
		public ICollection<Booking> MechanistBookings { get; set; }
	}
}
