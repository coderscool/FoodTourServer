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
    public class ProjectCartWhenCartItemRemoveInteractor : IQueryInteractor<DomainEvent.CartItemRemove>
    {
        private readonly IProjectionGateway<Projection.Cart> _projectionGateway;
        public ProjectCartWhenCartItemRemoveInteractor(IProjectionGateway<Projection.Cart> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.CartItemRemove @event, CancellationToken cancellationToken)
            => await _projectionGateway.DeleteAsync(x => x.Id == @event.AggregateId, cancellationToken);
    }
}
