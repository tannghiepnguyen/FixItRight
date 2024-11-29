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
		public async Task<IActionResult> GetRepairServicesAsync()
		{
			var services = await serviceManager.RepairServiceService.GetRepairServicesAsync(false);
			return Ok(services);
		}

		[HttpGet("active")]
		public async Task<IActionResult> GetActiveRepairServicesAsync()
		{
			var services = await serviceManager.RepairServiceService.GetActiveRepairServicesAsync(false);
			return Ok(services);
		}

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> GetRepairServiceByIdAsync(Guid id)
		{
			var service = await serviceManager.RepairServiceService.GetRepairServiceByIdAsync(id, false);
			return Ok(service);
		}

		[HttpPost]
		public async Task<IActionResult> AddRepairServiceAsync(ServiceForCreationDto repairService)
		{
			var service = await serviceManager.RepairServiceService.AddRepairServiceAsync(repairService);
			return CreatedAtAction(nameof(GetRepairServiceByIdAsync), new { id = service.Id }, service);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateRepairServiceAsync(Guid id, ServiceForUpdateDto repairService)
		{
			await serviceManager.RepairServiceService.UpdateRepairServiceAsync(id, repairService, true);
			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteRepairServiceAsync(Guid id)
		{
			await serviceManager.RepairServiceService.DeleteRepairServiceAsync(id, true);
			return NoContent();
		}
	}
}
