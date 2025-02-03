﻿using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FixItRight_Infrastructure.Repositories
{
	public class RepairServiceRepository : RepositoryBase<Service>, IRepairServiceRepository
	{
		public RepairServiceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void AddRepairServiceAsync(Service repairService) => Create(repairService);

		public void DeleteRepairServiceAsync(Service repairService) => Delete(repairService);

		public async Task<PagedList<Service>> GetActiveRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange)
		{
			var services = await FindByCondition(s => s.Active, trackChange).ToListAsync();
			return PagedList<Service>.ToPagedList(services, repairServiceParameters.PageNumber, repairServiceParameters.PageSize);
		}

		public async Task<Service?> GetRepairServiceByIdAsync(Guid id, bool trackChange) => await FindByCondition(s => s.Id.Equals(id), trackChange).Include(s => s.Category).SingleOrDefaultAsync();

		public async Task<PagedList<Service>> GetRepairServicesAsync(RepairServiceParameters repairServiceParameters, bool trackChange)
		{
			var services = FindAll(trackChange).Include(s => s.Category)
				.Where(c => c.Active == repairServiceParameters.Active);
			if (!string.IsNullOrWhiteSpace(repairServiceParameters.SearchName))
			{
				var searchTerm = repairServiceParameters.SearchName.Trim().ToLower();
				services = services.Where(c => c.Name.Trim().ToLower().Contains(searchTerm));
			}
			services = services.Where(c => c.CategoryId.Equals(repairServiceParameters.CategoryId));
			return PagedList<Service>.ToPagedList(await services.ToListAsync(), repairServiceParameters.PageNumber, repairServiceParameters.PageSize);
		}

	}
}
