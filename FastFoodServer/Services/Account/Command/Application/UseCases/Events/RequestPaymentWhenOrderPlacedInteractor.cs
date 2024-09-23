using Application.Abstractions;
using Contracts.Services.Account;
using Domain.Aggregates;
using Order = Contracts.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;

namespace Application.UseCases.Events
{
    public class RequestPaymentWhenOrderPlacedInteractor : IInteractor<Order.DomainEvent.OrderAddItem>
    {
        private readonly IApplicationService _applicationService;

        public RequestPaymentWhenOrderPlacedInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderAddItem @event, CancellationToken cancellationToken)
        {
            var account = await _applicationService.LoadAggregateAsync<Account>(@event.CustomerId, cancellationToken);
            account.Handle(new Command.RequestPayment(@event.CustomerId, @event.AggregateId, @event.Price, @event.Quantity));
            await _applicationService.AppendEventsAsync(account, cancellationToken);
        }
    }
}
