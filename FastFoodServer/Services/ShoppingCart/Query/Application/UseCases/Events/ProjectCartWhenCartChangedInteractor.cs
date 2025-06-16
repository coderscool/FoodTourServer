using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.ShoppingCart;

namespace Application.UseCases.Events
{
    public interface IProjectCartWhenCartChangedInteractor 
        : IInteractor<DomainEvent.CartCreate>,
          IInteractor<DomainEvent.CartChangeCustomer>,
          IInteractor<DomainEvent.CartChangeDescription>,
          IInteractor<DomainEvent.CartItemAdd>,
          IInteractor<DomainEvent.CartRemove>,
          IInteractor<DomainEvent.CartItemChangedQuantity>{ }
    public class ProjectCartWhenCartChangedInteractor : IProjectCartWhenCartChangedInteractor
    {
        private readonly IProjectionGateway<Projection.Cart> _projectionGateway;
        public ProjectCartWhenCartChangedInteractor(IProjectionGateway<Projection.Cart> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.CartCreate @event, CancellationToken cancellationToken)
        {
            Projection.Cart shoppingCartDetails = new(
                @event.CartId,
                @event.CustomerId,
                @event.Customer,
                @event.Description,
                @event.Total,
                @event.Status,
                @event.Version
            );

            await _projectionGateway.ReplaceInsertAsync(shoppingCartDetails, cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.CartChangeCustomer @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: cart => cart.Customer,
                value: @event.Customer,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.CartChangeDescription @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: cart => cart.Description,
                value: @event.Description,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.CartItemAdd @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.CartId,
                version: @event.Version,
                field: cart => cart.Status,
                value: @event.Status,
                cancellationToken: cancellationToken);

        public async Task InteractAsync(DomainEvent.CartRemove @event, CancellationToken cancellationToken)
            => await _projectionGateway.DeleteAsync(@event.CartId, cancellationToken);

        public async Task InteractAsync(DomainEvent.CartItemChangedQuantity @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.CartId,
                version: @event.Version,
                field: cart => cart.Total,
                value: @event.Total,
                cancellationToken: cancellationToken);
    }
}
