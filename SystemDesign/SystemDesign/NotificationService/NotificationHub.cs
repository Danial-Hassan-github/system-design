using Microsoft.AspNetCore.SignalR;
namespace SystemDesign.NotificationService
{
    public class NotificationHub:Hub
    {
        public async Task SendNotification(string name, string data)
        {
            await Clients.All.SendAsync("ReceiveNotification", name, data);
        }
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");

            await base.OnDisconnectedAsync(exception);
        }
    }
}
