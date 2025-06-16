using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.ShoppingCart;

namespace Application.UseCases.Events
{
    public interface IProjectCartItemWhenCartItemChangedInteractor :
        IInteractor<DomainEvent.CartItemAdd>,
        IInteractor<DomainEvent.CartItemRemove>,
        IInteractor<DomainEvent.CartRemove>,
        IInteractor<DomainEvent.CartItemChangedQuantity>{ }
    public class ProjectCartItemWhenCartItemChangedInteractor : IProjectCartItemWhenCartItemChangedInteractor
    {
        private readonly IProjectionGateway<Projection.CartItem> _projectionGateway;
        public ProjectCartItemWhenCartItemChangedInteractor(IProjectionGateway<Projection.CartItem> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.CartItemAdd @event, CancellationToken cancellationToken)
        {
            Projection.CartItem shoppingCartItem = new(
                @event.ItemId,
                @event.CartId,
                @event.RestaurantId,
                @event.DishId,
                @event.Restaurant,
                @event.Dish,
                @event.Price,
                @event.Quantity,
                @event.Note,
                @event.Choose,
                @event.CheckOut,
                @event.Version
            );
            await _projectionGateway.ReplaceInsertAsync(shoppingCartItem, cancellationToken);
        }

        public Task InteractAsync(DomainEvent.CartItemRemove @event, CancellationToken cancellationToken)
            => _projectionGateway.DeleteAsync(@event.Id, cancellationToken);

        public Task InteractAsync(DomainEvent.CartRemove @event, CancellationToken cancellationToken)
            => _projectionGateway.DeleteAsync(x => x.Id == @event.CartId, cancellationToken);

        public async Task InteractAsync(DomainEvent.CartItemChangedQuantity @event, CancellationToken cancellationToken)
            => await _projectionGateway.UpdateFieldAsync(
                id: @event.Id,
                version: @event.Version,
                field: cartItem => cartItem.Quantity,
                value: @event.Quantity,
                cancellationToken: cancellationToken);
    }
}
