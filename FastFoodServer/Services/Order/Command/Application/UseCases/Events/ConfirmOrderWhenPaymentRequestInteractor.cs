using Application.Abstractions;
using Account = Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using MassTransit;
using Domain.Aggregates;
using Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class ConfirmOrderWhenPaymentRequestInteractor : IInteractor<Account.DomainEvent.PaymentRequest>
    {
        private readonly IApplicationService _applicationService;
        public ConfirmOrderWhenPaymentRequestInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Account.DomainEvent.PaymentRequest @event, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Order>(@event.OrderId, cancellationToken);
            order.Handle(new Command.ConfirmOrder(@event.OrderId));
            await _applicationService.PublishEventAsync(order, cancellationToken);
        }
    }
}
