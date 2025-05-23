﻿using FixItRight_Domain.Models;
using FixItRight_Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Persistence
{
	public class RepositoryContext : IdentityDbContext<User>
	{
		private readonly UserManager<User> userManager;

		public RepositoryContext(DbContextOptions option) : base(option)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new CategoryConfiguration());
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new ServiceConfiguration());
			builder.ApplyConfiguration(new BookingConfiguration());
			builder.ApplyConfiguration(new ChatConfiguration());
			builder.ApplyConfiguration(new RatingConfiguration());
			builder.ApplyConfiguration(new TransactionConfiguration());
			builder.ApplyConfiguration(new RoleConfiguration());
			builder.ApplyConfiguration(new UserRoleConfiguration());

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Rating> Ratings { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
