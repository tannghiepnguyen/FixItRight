using FixItRight_Service.ChatServices.DTOs;
using FixItRight_Service.IServices;
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
		public IActionResult GetAllChats([FromRoute] Guid bookingId)
		{
			var chats = serviceManager.ChatService.GetChatsByBookingId(bookingId, false);
			return Ok(new
			{
				data = chats
			});
		}

		[HttpPost]
		public IActionResult CreateChat([FromForm] ChatForCreationDto chat)
		{
			var newChat = serviceManager.ChatService.CreateChat(chat);
			return StatusCode(201);

		}
	}
}
