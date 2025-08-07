using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;
using Delivery = Contracts.Services.Delivery;

namespace Application.UseCases.Events
{
    public class RequireCompleteOrderWhenRequireCompleteDeliveryInteractor : IInteractor<Delivery.DomainEvent.DeliveryRequireComplete>
    {
        private readonly IApplicationService _applicationService;
        public RequireCompleteOrderWhenRequireCompleteDeliveryInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Delivery.DomainEvent.DeliveryRequireComplete @event, CancellationToken cancellationToken)
        {
            var delivery = await _applicationService.LoadAggregateAsync<Order>(@event.OrderId, cancellationToken);
            delivery.Handle(new Command.RequireCompleteOrder(@event.ItemId, @event.OrderId));
            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
