using Infrastructure.Hubs.Abstractions;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace SignalRNotification.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly IQueueService _queueService;
        public NotificationHub(IQueueService queueService)
        {
            _queueService = queueService;
        }
        public async Task OnConnectedAsync(string id)
        {
            _queueService.AppendUserConnection(id, Context.ConnectionId);
            Console.WriteLine(Context.ConnectionId);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _queueService.RemoveUserConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
