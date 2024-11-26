using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class ServiceConfiguration : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.HasKey(s => s.Id);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.Property(s => s.Image).IsRequired();
			builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
			builder.Property(s => s.Description).IsRequired().HasMaxLength(200);
			builder.Property(s => s.Price).IsRequired();
			builder.Property(s => s.Active).IsRequired();
			builder.Property(s => s.CreatedAt).IsRequired();
			builder.Property(s => s.UpdatedAt);
			builder.HasMany(s => s.Bookings).WithOne(b => b.Service).HasForeignKey(b => b.ServiceId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
