using Application.Abstractions;
using Application.Services;
using Order = Contracts.Services.Order;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Services.Payment;

namespace Application.UseCases.Events
{
    public class RequestPaymentWhenOrderPlacedInteractor : IInteractor<Order.DomainEvent.OrderPlaced>
    {
        private readonly IApplicationService _applicationService;
        public RequestPaymentWhenOrderPlacedInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderPlaced @event, CancellationToken cancellationToken)
        {
            var payment = await _applicationService.LoadAggregateAsync<Payment>(@event.CustomerId, cancellationToken);
            payment.Handle(new Command.RequestPayment(@event.CustomerId, @event.Id, @event.Total));
            await _applicationService.AppendEventsAsync(payment, cancellationToken);
        }
    }
}
