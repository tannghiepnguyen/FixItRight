using AutoMapper;
using FixItRight_Domain.Models;
using FixItRight_Domain.Repositories;
using FixItRight_Service.ChatServices.DTOs;
using FixItRight_Service.IServices;
using Microsoft.AspNetCore.SignalR;

namespace FixItRight_Service.ChatServices
{
	internal sealed class ChatService : IChatService
	{
		private readonly IRepositoryManager repositoryManager;
		private readonly ILoggerManager logger;
		private readonly IMapper mapper;
		private readonly IHubContext<MessageHub> hubContext;

		public ChatService(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper, IHubContext<MessageHub> hubContext)
		{
			this.repositoryManager = repositoryManager;
			this.logger = logger;
			this.mapper = mapper;
			this.hubContext = hubContext;
		}
		public async Task CreateChat(ChatForCreationDto chatForCreationDto)
		{
			await hubContext.Clients.Group(chatForCreationDto.BookingId.ToString()).SendAsync("ReceiveMessage", chatForCreationDto.SenderId, chatForCreationDto.Message);
			var chat = mapper.Map<Chat>(chatForCreationDto);
			chat.CreatedAt = DateTime.UtcNow;
			repositoryManager.ChatRepository.CreateChat(chat);
			await repositoryManager.SaveAsync();
		}

		public async Task<IEnumerable<ChatForReturnDto>> GetChatsByBookingId(Guid bookingId, bool trackChange)
		{
			var chats = await repositoryManager.ChatRepository.GetChatsByBookingId(bookingId, trackChange);
			return mapper.Map<IEnumerable<ChatForReturnDto>>(chats);

		}
	}
}
