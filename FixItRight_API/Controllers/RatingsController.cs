using FixItRight_Domain.Constants;
using FixItRight_Service.IServices;
using FixItRight_Service.RatingServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/ratings")]
	[ApiController]
	public class RatingsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public RatingsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet("{bookingId:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize]
		public async Task<IActionResult> GetRatingByBookingId([FromRoute] Guid bookingId)
		{
			var ratings = await serviceManager.RatingService.GetRatingByBookingId(bookingId, false);
			return Ok(new
			{
				data = ratings
			});
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RatingForReturnDto))]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[Authorize(Roles = $"{nameof(Role.Customer)}")]
		public async Task<IActionResult> AddRating([FromForm] RatingForCreationDto rating)
		{
			var newRating = await serviceManager.RatingService.CreateRating(rating);
			return CreatedAtAction(nameof(GetRatingByBookingId), new { bookingId = newRating.BookingId }, newRating);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RatingForReturnDto>))]
		[Authorize(Roles = $"{nameof(Role.Admin)}")]
		public async Task<IActionResult> GetRatings()
		{
			var ratings = await serviceManager.RatingService.GetRatings(false);
			return Ok(new
			{
				data = ratings
			});
		}
	}
}
