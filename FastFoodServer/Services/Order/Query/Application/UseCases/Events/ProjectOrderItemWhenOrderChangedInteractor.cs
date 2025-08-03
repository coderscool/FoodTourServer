using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public interface IProjectOrderItemWhenOrderChangedInteractor :
        IInteractor<DomainEvent.OrderPlaced>,
        IInteractor<DomainEvent.OrderConfirm>,
        IInteractor<DomainEvent.OrderCompleteDish>,
        IInteractor<DomainEvent.OrderRequire>,
        IInteractor<DomainEvent.OrderConfirmRequire>;
    public class ProjectOrderItemWhenOrderChangedInteractor : IProjectOrderItemWhenOrderChangedInteractor
    {
        private readonly IProjectionGateway<Projection.OrderGroup> _projectionGateway;
        public ProjectOrderItemWhenOrderChangedInteractor(IProjectionGateway<Projection.OrderGroup> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.OrderPlaced @event, CancellationToken cancellationToken)
        {
            foreach(var item in @event.Items)
            {
                Projection.OrderGroup orderItem = new(item.GroupId, @event.Id, item.RestaurantId, @event.CustomerId,
                    item.Restaurant, @event.Customer, item.OrderItem, item.Status, @event.Date, @event.Version);

                await _projectionGateway.ReplaceInsertAsync(orderItem, cancellationToken);
            }
        }

        public async Task InteractAsync(DomainEvent.OrderConfirm @event, CancellationToken cancellationToken)
        {
            await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.Status,
                value: @event.Status,
                cancellationToken: cancellationToken);

            await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.Restaurant,
                value: @event.Restaurant,
                cancellationToken: cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.OrderCompleteDish @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.Status,
                value: @event.Status,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.OrderRequire @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.Status,
                value: @event.Status,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.OrderConfirmRequire @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.ItemId,
                version: @event.Version,
                field: orderItem => orderItem.Status,
                value: @event.Status,
                cancellationToken: cancellationToken);
    }
}
