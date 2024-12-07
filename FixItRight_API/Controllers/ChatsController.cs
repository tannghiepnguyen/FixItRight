using FixItRight_Domain.Constants;
using FixItRight_Service.ChatServices.DTOs;
using FixItRight_Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FixItRight_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChatsController : ControllerBase
	{
		private readonly IServiceManager serviceManager;

		public ChatsController(IServiceManager serviceManager)
		{
			this.serviceManager = serviceManager;
		}

		[HttpGet("{bookingId:guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Authorize(Roles = $"{nameof(Role.Customer)},{nameof(Role.Mechanist)}")]
		public IActionResult GetAllChats([FromRoute] Guid bookingId)
		{
			var chats = serviceManager.ChatService.GetChatsByBookingId(bookingId, false);
			return Ok(new
			{
				data = chats
			});
		}

		[HttpPost]
		[Authorize(Roles = $"{nameof(Role.Customer)},{nameof(Role.Mechanist)}")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public IActionResult CreateChat([FromForm] ChatForCreationDto chat)
		{
			var newChat = serviceManager.ChatService.CreateChat(chat);
			return StatusCode(201);

		}
	}
}
