using Application.Abstractions;
using Application.Services;
using Contracts.Services.Delivery;
using Domain.Aggregates;
using Order = Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class ReceiveDishDeliveryWhenOrderConfirmRequireInteractor : IInteractor<Order.DomainEvent.OrderConfirmRequire>
    {
        private readonly IApplicationService _applicationService;
        public ReceiveDishDeliveryWhenOrderConfirmRequireInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderConfirmRequire @event, CancellationToken cancellationToken)
        {
            var delivery = await _applicationService.LoadAggregateAsync<Delivery>(@event.ItemId, cancellationToken);
            delivery.Handle(new Command.ReceiveDishDelivery(@event.ItemId, @event.Confirm));
            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
