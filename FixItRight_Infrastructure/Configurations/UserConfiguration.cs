using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(u => u.Fullname).IsRequired();
			builder.Property(u => u.Active).IsRequired();
			builder.Property(u => u.Avatar);
			builder.Property(u => u.Gender).HasConversion<string>().IsRequired();
			builder.Property(u => u.Birthday).IsRequired();
			builder.Property(u => u.IsVerified).IsRequired();
			builder.Property(u => u.CccdFront);
			builder.Property(u => u.CccdBack);
			builder.Property(u => u.CreatedAt).IsRequired();
			builder.Property(u => u.UpdatedAt);
			builder.HasMany(u => u.CustomerChats).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.MechanistChats).WithOne(c => c.Mechanist).HasForeignKey(c => c.MechanistId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.CustomerBookings).WithOne(b => b.Customer).HasForeignKey(b => b.CustomerId).OnDelete(DeleteBehavior.NoAction);
			builder.HasMany(u => u.MechanistBookings).WithOne(b => b.Mechanist).HasForeignKey(c => c.MechanistId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
