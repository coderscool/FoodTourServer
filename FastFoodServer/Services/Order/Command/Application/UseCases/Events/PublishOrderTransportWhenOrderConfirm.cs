using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;

namespace Application.UseCases.Events
{
    public class PublishOrderTransportWhenOrderConfirm : IInteractor<DomainEvent.OrderConfirm>
    {
        private readonly IApplicationService _applicationService;
        public PublishOrderTransportWhenOrderConfirm(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(DomainEvent.OrderConfirm @event, CancellationToken cancellationToken)
        {
            if (@event.Confirm)
            {
                var order = await _applicationService.LoadAggregateAsync<Order>(@event.OrderId, cancellationToken);
                SummaryEvent.OrderTransport orderTransport = new(order, order.Version);
                await _applicationService.PublishEventAsync(orderTransport, cancellationToken);
            }
        }
    }
}
