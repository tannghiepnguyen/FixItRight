using FixItRight_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(c => c.Id);
			builder.Property(t => t.Id).ValueGeneratedOnAdd();
			builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
			builder.HasMany(c => c.Services).WithOne(s => s.Category).HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.NoAction);

			builder.HasData(
				new Category
				{
					Id = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f"),
					Name = "Electricity"
				},
				new Category
				{
					Id = Guid.Parse("150dcc51-3c46-4b48-bcbb-ec9bf217edfb"),
					Name = "Plumber"
				}
			);
		}
	}
}
