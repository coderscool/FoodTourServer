using Application.Abstractions;
using Application.Services;
using Contracts.Services.Notification;
using Order = Contracts.Services.Order;
using Domain.Aggregates;
using Infrastructure.Hubs.Abstractions;
using Microsoft.AspNetCore.SignalR;
using SignalRNotification.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.UseCases.Events
{
    public class NotificationWhenOrderConfirmInteractor : IInteractor<Order.DomainEvent.OrderConfirm>
    {
        private readonly IApplicationService _applicationService;
        private readonly IQueueService _queueService;
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationWhenOrderConfirmInteractor(IApplicationService applicationService,
            IQueueService queueService, IHubContext<NotificationHub> hubContext)
        {
            _applicationService = applicationService;
            _queueService = queueService;
            _hubContext = hubContext;
        }

        public async Task InteractAsync(Order.DomainEvent.OrderConfirm @event, CancellationToken cancellationToken)
        {
            //var s = _queueService.GetConnectionId(@event.RestaurantId);
            //await _hubContext.Clients.Client(s).SendAsync("ReceiveNotification", "order");
            //var message = Message(@event.Name, @event.Quantity);
            //Notification notification = new();
            //notification.Handle(new Command.NotificationMessage(@event.CustomerId, @event.Name, message));
            //await _applicationService.AppendEventsAsync(notification, cancellationToken);
        }

        private string Message(string Dish, int Amount)
        {
            var sb = new StringBuilder();
            sb.Append("Đặt");
            sb.Append(Amount);
            sb.Append(" phần");
            sb.Append(Dish);
            return sb.ToString();
        }
    }
}
