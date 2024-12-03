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
    public class ProjectCartWhenAddCartItemInteractor : IQueryInteractor<DomainEvent.CartItemAdd>
    {
        private readonly IProjectionGateway<Projection.Cart> _projectionGateway;

        public ProjectCartWhenAddCartItemInteractor(IProjectionGateway<Projection.Cart> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.CartItemAdd @event, CancellationToken cancellationToken)
        {
            var item = new Projection.Cart
            {
                Id = @event.AggregateId,
                RestaurantId = @event.RestaurantId,
                CustomerId = @event.CustomerId,
                DishId = @event.DishId,
                Amount = @event.Amount
            };
            Console.WriteLine(@event.AggregateId);
            await _projectionGateway.ReplaceInsertAsync(item, cancellationToken);
        }
    }
}
