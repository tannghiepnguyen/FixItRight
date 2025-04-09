using FixItRight_Domain.Constants;
using FixItRight_Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{

		public UserConfiguration()
		{
		}
		public async void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(u => u.Fullname);
			builder.Property(u => u.Active).IsRequired();
			builder.Property(u => u.Avatar);
			builder.Property(u => u.Gender).HasConversion<string>();
			builder.Property(u => u.Birthday);
			builder.Property(u => u.CccdFront);
			builder.Property(u => u.CccdBack);
			builder.Property(u => u.CreatedAt).IsRequired();
			builder.Property(u => u.UpdatedAt);
			builder.Property(u => u.PasswordResetToken);
			builder.Property(u => u.PasswordResetTokenExpiryTime);
			builder.Property(u => u.Address);
			builder.Property(u => u.Balance).IsRequired();
			builder.HasMany(u => u.Chats).WithOne(c => c.Sender).HasForeignKey(c => c.SenderId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.CustomerBookings).WithOne(b => b.Customer).HasForeignKey(b => b.CustomerId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.MechanistBookings).WithOne(b => b.Mechanist).HasForeignKey(c => c.MechanistId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.Transactions).WithOne(t => t.User).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.NoAction);

			var user = new User
			{
				Id = "34e5bee4-75cb-423b-b8a3-58e5d0175989",
				UserName = "admin",
				NormalizedUserName = "ADMIN",
				Email = "admin@gmail.com",
				EmailConfirmed = true,
				Avatar = "https://media.istockphoto.com/vectors/default-profile-picture-avatar-photo-placeholder-vector-illustration-vector-id1223671392?k=6&m=1223671392&s=170667a&w=0&h=zP3l7WJinOFaGb2i1F4g8IS2ylw0FlIaa6x3tP9sebU=",
				Fullname = "Admin",
				Gender = Gender.Male,
				Birthday = new DateOnly(2002, 1, 23),
				CreatedAt = DateTime.Now,
				Active = true,
				Address = "TPHCM"
			};
			user.PasswordHash = new PasswordHasher<User>().HashPassword(user, "admin");
			builder.HasData(user);
		}
	}
}
