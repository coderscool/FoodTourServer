using Application.Abstractions;
using Application.Services;
using Contracts.Services.Delivery;
using Domain.Aggregates;
using Order = Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class CompleteDeliveryWhenOrderCompleteInteractor : IInteractor<Order.DomainEvent.OrderComplete>
    {
        private readonly IApplicationService _applicationService;
        public CompleteDeliveryWhenOrderCompleteInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderComplete @event, CancellationToken cancellationToken)
        {
            var delivery = await _applicationService.LoadAggregateAsync<Delivery>(@event.ItemId, cancellationToken);
            delivery.Handle(new Command.CompleteDelivery(@event.ItemId, @event.Confirm));
            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
