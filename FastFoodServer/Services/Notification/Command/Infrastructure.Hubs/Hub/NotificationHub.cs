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
        public override Task OnConnectedAsync()
        {
            string userId = Context.GetHttpContext().Request.Query["userId"];
            _queueService.AppendUserConnection(userId, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _queueService.RemoveUserConnection(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
