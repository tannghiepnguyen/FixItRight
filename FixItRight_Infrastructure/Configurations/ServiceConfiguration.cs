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
			builder.Property(s => s.Image);
			builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
			builder.Property(s => s.Description).IsRequired().HasMaxLength(200);
			builder.Property(s => s.Price).IsRequired();
			builder.Property(s => s.Active).IsRequired();
			builder.Property(s => s.CreatedAt).IsRequired();
			builder.Property(s => s.UpdatedAt);
			builder.HasMany(s => s.Bookings).WithOne(b => b.Service).HasForeignKey(b => b.ServiceId).OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(s => s.Category).WithMany(c => c.Services).HasForeignKey(s => s.CategoryId).OnDelete(DeleteBehavior.NoAction);

			builder.HasData(
				new Service
				{
					Id = Guid.Parse("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/fridge.jpg",
					Name = "Fridge Repair",
					Description = "Fridge Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("85aa164a-a52c-4af3-95fd-29890f8df531"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/aircondition.jpg",
					Name = "Air Condition Repair",
					Description = "Air Condition Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/washing.jpg",
					Name = "Washing Machine Repair",
					Description = "Washing Machine Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/tv.jpg",
					Name = "TV Repair",
					Description = "TV Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("a838bccb-7786-462f-b4b0-018b9ce03560"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/microwave.jpg",
					Name = "Microwave Repair",
					Description = "Microwave Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("8f19e546-a41d-488a-85df-558af0caf391"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/oven.jpg",
					Name = "Oven Repair",
					Description = "Oven Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/dishwasher.jpg",
					Name = "Dishwasher Repair",
					Description = "Dishwasher Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("9ca4ae5b-c18d-4115-821f-3a28ed7a416f")
				},
				new Service
				{
					Id = Guid.Parse("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/pipe.jpg",
					Name = "Pipe Repair",
					Description = "Pipe Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("150dcc51-3c46-4b48-bcbb-ec9bf217edfb")
				},
				new Service
				{
					Id = Guid.Parse("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/sink.jpg",
					Name = "Sink Repair",
					Description = "Sink Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("150dcc51-3c46-4b48-bcbb-ec9bf217edfb")
				},
				new Service
				{
					Id = Guid.Parse("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/toilet.jpg",
					Name = "Toilet Repair",
					Description = "Toilet Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("150dcc51-3c46-4b48-bcbb-ec9bf217edfb")
				},
				new Service
				{
					Id = Guid.Parse("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
					Image = "https://fixitright.blob.core.windows.net/fixitright/shower.jpg",
					Name = "Shower Repair",
					Description = "Shower Repair",
					Price = 200000,
					Active = true,
					CreatedAt = DateTime.Now,
					CategoryId = Guid.Parse("150dcc51-3c46-4b48-bcbb-ec9bf217edfb")
				}
			);
		}
	}
}
