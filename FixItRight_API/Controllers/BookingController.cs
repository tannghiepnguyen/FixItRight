using FixItRight_Domain;
using FixItRight_Domain.Constants;
using FixItRight_Domain.RequestFeatures;
using FixItRight_Service.BookingServices.DTOs;
using FixItRight_Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

		[HttpPost("get-bookings")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetBookings([FromQuery] BookingParameters bookingParameters)
		{
			var pagedResult = await serviceManager.BookingService.GetBookings(bookingParameters, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<BookingForReturnDto>()
				{
					Data = pagedResult.bookings,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpPost("get-bookings-by-mechanist/{mechanistId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Mechanist)}")]
		public async Task<IActionResult> GetBookingsByMechanistId([FromRoute] string mechanistId, [FromQuery] BookingParameters bookingParameters)
		{
			var pagedResult = await serviceManager.BookingService.GetBookingsByMechanistId(bookingParameters, mechanistId, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<BookingForReturnDto>()
				{
					Data = pagedResult.bookings,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpPost("get-bookings-by-customer/{customerId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> GetBookingsByCustomerId([FromRoute] string customerId, [FromQuery] BookingParameters bookingParameters)
		{
			var pagedResult = await serviceManager.BookingService.GetBookingsByCustomerId(bookingParameters, customerId, false);
			Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
			return Ok(new
			{
				data = new CustomListResponse<BookingForReturnDto>()
				{
					Data = pagedResult.bookings,
					MetaData = pagedResult.metaData
				}
			});
		}

		[HttpGet("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize]
		public async Task<IActionResult> GetBooking([FromRoute] Guid id)
		{
			var bookings = await serviceManager.BookingService.GetBookingById(id, false);
			return Ok(new
			{
				data = bookings
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> CreateBooking([FromBody] BookingForCreationDto booking)
		{
			var paymentUrl = await serviceManager.BookingService.CreateBooking(booking);
			return Ok(new { data = paymentUrl });
		}

		[HttpPut("{id:guid}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[Authorize(Roles = $"{nameof(Role.Customer)}, {nameof(Role.Mechanist)}")]
		public async Task<IActionResult> UpdateBooking(Guid id, [FromBody] BookingForUpdateDto booking)
		{
			await serviceManager.BookingService.UpdateBooking(id, booking, true);
			return NoContent();
		}
	}
}
