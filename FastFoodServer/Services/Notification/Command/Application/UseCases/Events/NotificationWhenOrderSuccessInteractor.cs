using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class NotificationWhenOrderSuccessInteractor : IInteractor<DomainEvent.OrderAddItem>
    {
        private readonly IApplicationService _applicationService;
        private readonly IQueueService _queueService;
        public NotificationWhenOrderSuccessInteractor(IApplicationService applicationService, IQueueService queueService)
        {
            _applicationService = applicationService;
            _queueService = queueService;
        }

        public async Task InteractAsync(DomainEvent.OrderAddItem @event, CancellationToken cancellationToken)
        {
            Console.WriteLine("123");
            var account = await _applicationService.LoadAggregateAsync<Notification>(@event.AggregateId, cancellationToken);
            account.When(@event);
            Console.WriteLine(@event);
            //await _applicationService.AppendEventsAsync(account, cancellationToken);
            await _queueService.ScheduleNotification(@event.PersonId, Message(@event.Person.Name, @event.Dish.Name, @event.Amount), @event.Time);
            account.MarkChangesAsCommitted();
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
