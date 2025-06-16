using Application.Abstractions;
using Order = Contracts.Services.Order;
using Domain.Aggregates;
using Contracts.Services.Delivery;
using Application.Services;

namespace Application.UseCases.Events
{
    public class CreateDeliveryWhenOrderTransportInteractor : IInteractor<Order.SummaryEvent.OrderTransport>
    {
        private readonly IApplicationService _applicationService;
        public CreateDeliveryWhenOrderTransportInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.SummaryEvent.OrderTransport @event, CancellationToken cancellationToken)
        {
            Delivery delivery = new ();
            delivery.Handle(new Command.CreateDelivery(
                @event.Order.OrderId,
                @event.Order.Item.ItemId,
                @event.Order.Item.RestaurantId,
                @event.Order.CustomerId,
                @event.Order.Item.Restaurant,
                @event.Order.Customer,
                @event.Order.Item.Dish,
                @event.Order.Item.Quantity,
                @event.Order.Item.Price,
                @event.Order.Item.Status));

            await _applicationService.AppendEventsAsync(delivery, cancellationToken);
        }
    }
}
