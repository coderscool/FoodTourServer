using Application.Abstractions;
using Application.Services;
using Contracts.Services.Order;
using Domain.Aggregates;
using Delivery = Contracts.Services.Delivery;

namespace Application.UseCases.Events
{
    public class RequireOrderWhenDeiveryRequireDishInteractor : IInteractor<Delivery.DomainEvent.DeliveryRequireDish>
    {
        private readonly IApplicationService _applicationService;
        public RequireOrderWhenDeiveryRequireDishInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Delivery.DomainEvent.DeliveryRequireDish @event, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Order>(@event.OrderId, cancellationToken);
            order.Handle(new Command.RequireOrder(@event.OrderId, @event.ItemId));
            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
