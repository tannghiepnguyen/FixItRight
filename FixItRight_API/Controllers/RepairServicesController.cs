﻿using FixItRight_Domain;
using FixItRight_Domain.Constants;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.IServices;
using FixItRight_Service.RepairServiceServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FixItRight_API.Controllers
{
	[Route("api/repair-services")]
	[ApiController]
	public class RepairServicesController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public RepairServicesController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpPost("get-services")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> GetRepairServicesAsync([FromQuery] RepairServiceParameters repairServiceParameters)
		{
			var pagedResult = await serviceManager.RepairServiceService.GetRepairServicesAsync(repairServiceParameters, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<ServiceForReturnDto>()
				{
					Data = pagedResult.services,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpGet("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetRepairServiceById([FromRoute] Guid id)
		{
			var service = await serviceManager.RepairServiceService.GetRepairServiceByIdAsync(id, false);
			return Ok(new
			{
				data = service
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> AddRepairServiceAsync([FromBody] ServiceForCreationDto repairService)
		{
			var service = await serviceManager.RepairServiceService.AddRepairServiceAsync(repairService);
			return CreatedAtAction(nameof(GetRepairServiceById), new { id = service.Id }, service);
		}

		[HttpPut("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> UpdateRepairServiceAsync([FromRoute] Guid id, [FromBody] ServiceForUpdateDto repairService)
		{
			await serviceManager.RepairServiceService.UpdateRepairServiceAsync(id, repairService, true);
			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> DeleteRepairServiceAsync([FromRoute] Guid id)
		{
			await serviceManager.RepairServiceService.DeleteRepairServiceAsync(id, true);
			return NoContent();
		}
	}
}
