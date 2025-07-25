using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Delivery;
using System.Linq.Expressions;

namespace Application.UseCases.Events
{
    public interface IProjectDeliveryWhenDeliveryChangedInteractor :
        IInteractor<DomainEvent.DeliveryCreate>,
        IInteractor<DomainEvent.DeliveryUpdateOrder>,
        IInteractor<DomainEvent.DeliveryAddShipper>;
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
                null,
                @event.Items,
                @event.CompletePrepared,
                @event.Status,
                @event.Date,
                @event.Version
            );
            await _projectionGateway.ReplaceInsertAsync(delivery, cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.DeliveryUpdateOrder @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.CompletePrepared,
                value: @event.Status,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.DeliveryAddShipper @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldsAsync(
                id: @event.DeliveryId,
                version: 2,
                updates: new (Expression<Func<Projection.Delivery, object>>, object)[]
                {
                    (x => x.ShipperId, @event.Id),
                    (x => x.Shipper, @event.Shipper),
                    (x => x.Status, @event.Status)
                },
                cancellationToken);
    }
}
