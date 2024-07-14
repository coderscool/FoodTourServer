using Application.Abstractions;
using Application.Services;
using Contracts.Abstractions.Messages;
using Contracts.Services.Account;
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
    public class NotificationWhenOrderSuccessInteractor : IInteractor<DomainEvent.PaymentRequest>
    {
        private readonly IApplicationService _applicationService;
        private readonly IQueueService _queueService;
        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationWhenOrderSuccessInteractor(IApplicationService applicationService,
            IQueueService queueService, IHubContext<NotificationHub> hubContext)
        {
            _applicationService = applicationService;
            _queueService = queueService;
            _hubContext = hubContext;
        }

        public async Task InteractAsync(DomainEvent.PaymentRequest @event, CancellationToken cancellationToken)
        {
            Console.WriteLine("123");
            var s = _queueService.GetConnectionId(@event.RestaurantId);
            Console.WriteLine(s);
            await _hubContext.Clients.Client(s).SendAsync("ReceiveNotification", @event.Name);
        }

        private string Message(string Name, string Dish, int Amount)
        {
            var sb = new StringBuilder();
            sb.Append(Amount);
            sb.Append(" phần");
            sb.Append(Dish);
            sb.Append(" từ");
            sb.Append(Name);
            return sb.ToString();
        }
    }
}
