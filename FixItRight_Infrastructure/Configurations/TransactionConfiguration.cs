using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
	{
		public void Configure(EntityTypeBuilder<Transaction> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.Property(t => t.OrderCode).IsRequired();
			builder.Property(t => t.Amount).IsRequired();
			builder.Property(t => t.CreatedAt).IsRequired();
			builder.Property(t => t.Status).HasConversion<string>().IsRequired();
			builder.HasOne(c => c.User).WithMany(c => c.Transactions).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.NoAction);

		}
	}
}
