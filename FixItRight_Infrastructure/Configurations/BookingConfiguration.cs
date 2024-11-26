using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class BookingConfiguration : IEntityTypeConfiguration<Booking>
	{
		public void Configure(EntityTypeBuilder<Booking> builder)
		{
			builder.HasKey(b => b.Id);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.Property(b => b.BookingDate).IsRequired();
			builder.Property(b => b.Status).HasConversion<string>().IsRequired();
			builder.HasOne(b => b.Customer).WithMany(c => c.CustomerBookings).HasForeignKey(b => b.CustomerId);
			builder.HasOne(b => b.Mechanist).WithMany(c => c.MechanistBookings).HasForeignKey(b => b.MechanistId);
			builder.HasOne(b => b.Service).WithMany(c => c.Bookings).HasForeignKey(b => b.ServiceId);
			builder.HasOne(b => b.Rating).WithOne(c => c.Booking).HasForeignKey<Rating>(r => r.BookingId);
			builder.HasOne(b => b.Transaction).WithOne(c => c.Booking).HasForeignKey<Transaction>(t => t.BookingId);
		}
	}
}
