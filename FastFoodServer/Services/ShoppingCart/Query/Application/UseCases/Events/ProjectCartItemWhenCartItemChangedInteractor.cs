using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public interface IProjectCartItemWhenCartItemChangedInteractor :
        IInteractor<DomainEvent.CartItemAdd>,
        IInteractor<DomainEvent.CartItemRemove>,
        IInteractor<DomainEvent.CartRemove>{ }
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
                @event.Version
            );
            await _projectionGateway.ReplaceInsertAsync(shoppingCartItem, cancellationToken);
        }

        public Task InteractAsync(DomainEvent.CartItemRemove @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task InteractAsync(DomainEvent.CartRemove @event, CancellationToken cancellationToken)
            => _projectionGateway.DeleteAsync(x => x.Id == @event.CartId, cancellationToken);
    }
}
