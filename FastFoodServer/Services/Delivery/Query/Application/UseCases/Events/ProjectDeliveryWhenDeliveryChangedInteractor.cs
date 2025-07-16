using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Delivery;

namespace Application.UseCases.Events
{
    public interface IProjectDeliveryWhenDeliveryChangedInteractor :
        IInteractor<DomainEvent.DeliveryCreate>;
    public class ProjectDeliveryWhenDeliveryChangedInteractor : IProjectDeliveryWhenDeliveryChangedInteractor
    {
        private readonly IProjectionGateway<Projection.Delivery> _projectionGateway;
        public ProjectDeliveryWhenDeliveryChangedInteractor(IProjectionGateway<Projection.Delivery> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.DeliveryCreate @event, CancellationToken cancellationToken)
        {
            var delivery = new Projection.Delivery(
                @event.Id,
                @event.OrderId,
                @event.CustomerId,
                @event.RestaurantId,
                null,
                @event.Restaurant,
                @event.Customer,
                @event.Dish,
                null,
                @event.Quantity,
                @event.Price,
                @event.OrderStatus,
                @event.Status,
                @event.Date,
                @event.Version
            );
            await _projectionGateway.ReplaceInsertAsync(delivery, cancellationToken);
        }
    }
}
