using FixItRight_Service.IServices;
using FixItRight_Service.RepairServiceServices.DTOs;
using Microsoft.AspNetCore.Mvc;

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

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ServiceForReturnDto>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetRepairServicesAsync()
		{
			var services = await serviceManager.RepairServiceService.GetRepairServicesAsync(false);
			return Ok(new
			{
				data = services
			});
		}

		[HttpGet("active")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ServiceForReturnDto>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetActiveRepairServicesAsync()
		{
			var services = await serviceManager.RepairServiceService.GetActiveRepairServicesAsync(false);
			return Ok(new
			{
				data = services
			});
		}

		[HttpGet("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceForReturnDto))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetRepairServiceByIdAsync([FromRoute] Guid id)
		{
			var service = await serviceManager.RepairServiceService.GetRepairServiceByIdAsync(id, false);
			return Ok(new
			{
				data = service
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ServiceForReturnDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> AddRepairServiceAsync([FromForm] ServiceForCreationDto repairService)
		{
			var service = await serviceManager.RepairServiceService.AddRepairServiceAsync(repairService);
			return CreatedAtAction(nameof(GetRepairServiceByIdAsync), new { id = service.Id }, service);
		}

		[HttpPut("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateRepairServiceAsync([FromRoute] Guid id, [FromForm] ServiceForUpdateDto repairService)
		{
			await serviceManager.RepairServiceService.UpdateRepairServiceAsync(id, repairService, true);
			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteRepairServiceAsync([FromRoute] Guid id)
		{
			await serviceManager.RepairServiceService.DeleteRepairServiceAsync(id, true);
			return NoContent();
		}
	}
}
