using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class ChatConfiguration : IEntityTypeConfiguration<Chat>
	{
		public void Configure(EntityTypeBuilder<Chat> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.Property(c => c.Message).IsRequired();
			builder.Property(c => c.CreatedAt).IsRequired();
			builder.HasOne(c => c.Sender).WithMany(c => c.Chats).HasForeignKey(c => c.SenderId).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(c => c.Booking).WithMany(b => b.Chats).HasForeignKey(c => c.BookingId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
