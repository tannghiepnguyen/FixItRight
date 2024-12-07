using FixItRight_Domain.Constants;
using FixItRight_Service.BookingServices.DTOs;
using FixItRight_Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/bookings")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public BookingController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetBookings()
		{
			var bookings = await serviceManager.BookingService.GetBookings(false);
			return Ok(new
			{
				data = bookings
			});
		}

		[HttpGet("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize]
		public async Task<IActionResult> GetBooking(Guid id)
		{
			var bookings = await serviceManager.BookingService.GetBookingById(id, false);
			return Ok(new
			{
				data = bookings
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> CreateBooking([FromForm] BookingForCreationDto booking)
		{
			var newBooking = await serviceManager.BookingService.CreateBooking(booking);
			return CreatedAtAction(nameof(GetBooking), new { id = newBooking.Id }, newBooking);
		}

		[HttpPut("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize(Roles = $"{nameof(Role.Customer)}, {nameof(Role.Mechanist)}")]
		public async Task<IActionResult> UpdateBooking(Guid id, [FromForm] BookingForUpdateDto booking)
		{
			await serviceManager.BookingService.UpdateBooking(id, booking, true);
			return NoContent();
		}
	}
}
