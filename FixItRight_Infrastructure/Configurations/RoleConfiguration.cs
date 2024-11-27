using FixItRight_Domain.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FixItRight_Infrastructure.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
			new IdentityRole
			{
				Id = "a0bf18ce-48d8-4f97-820e-97b5af1974c8",
				Name = Role.Admin,
				NormalizedName = Role.Admin.ToUpper()
			},
			new IdentityRole
			{
				Id = "b37d904e-16fb-4cda-8c3b-6f7f15f5819d",
				Name = Role.Customer,
				NormalizedName = Role.Customer.ToUpper()
			},
			new IdentityRole
			{
				Id = "bee3179d-722c-404b-95c7-d3ae5c260d40",
				Name = Role.Mechanist,
				NormalizedName = Role.Mechanist.ToUpper()
			}
		);
		}
	}
}
