using Microsoft.AspNetCore.SignalR;

namespace FixItRight_Service.ChatServices
{
	public class MessageHub : Hub
	{
		public override Task OnConnectedAsync()
		{
			Clients.All.SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} joined the chat");
			return base.OnConnectedAsync();
		}

		public override Task OnDisconnectedAsync(Exception? exception)
		{
			Clients.All.SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} left the chat");
			return base.OnDisconnectedAsync(exception);
		}

		public async Task JoinGroup(string bookingId)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, bookingId.ToString());
			await Clients.Group(bookingId.ToString()).SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} joined the group");
		}

		public async Task LeaveGroup(string bookingId)
		{
			await Groups.RemoveFromGroupAsync(Context.ConnectionId, bookingId.ToString());
			await Clients.Group(bookingId.ToString()).SendAsync("ReceiveMessage", "System", $"{Context.ConnectionId} left the group");
		}
	}
}
