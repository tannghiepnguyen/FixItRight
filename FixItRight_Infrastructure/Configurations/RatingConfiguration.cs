using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class RatingConfiguration : IEntityTypeConfiguration<Rating>
	{
		public void Configure(EntityTypeBuilder<Rating> builder)
		{
			builder.HasKey(r => r.Id);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.Property(r => r.Score).IsRequired();
			builder.Property(r => r.Comment).HasMaxLength(500);
			builder.HasOne(r => r.Booking).WithOne(c => c.Rating).HasForeignKey<Rating>(r => r.BookingId);
		}
	}
}
