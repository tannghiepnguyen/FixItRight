using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(u => u.Fullname);
			builder.Property(u => u.Active).IsRequired();
			builder.Property(u => u.Avatar);
			builder.Property(u => u.Gender).HasConversion<string>();
			builder.Property(u => u.Birthday);
			builder.Property(u => u.IsVerified).IsRequired();
			builder.Property(u => u.CccdFront);
			builder.Property(u => u.CccdBack);
			builder.Property(u => u.CreatedAt).IsRequired();
			builder.Property(u => u.UpdatedAt);
			builder.Property(u => u.Address);
			builder.HasMany(u => u.Chats).WithOne(c => c.Sender).HasForeignKey(c => c.SenderId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.CustomerBookings).WithOne(b => b.Customer).HasForeignKey(b => b.CustomerId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.MechanistBookings).WithOne(b => b.Mechanist).HasForeignKey(c => c.MechanistId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.Transactions).WithOne(t => t.User).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
