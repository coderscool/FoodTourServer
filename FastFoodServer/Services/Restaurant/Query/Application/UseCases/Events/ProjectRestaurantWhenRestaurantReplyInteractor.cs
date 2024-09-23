using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectRestaurantWhenRestaurantReplyInteractor : IInteractor<DomainEvent.RestaurantReply>
    {
        private readonly IProjectionGateway<Projection.Restaurant> _projectionGateway;
        public ProjectRestaurantWhenRestaurantReplyInteractor(IProjectionGateway<Projection.Restaurant> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            var restaurant = await _projectionGateway.FindAsync(x => x.Id == @event.AggregateId, cancellationToken);
            if (restaurant == null)
            {
                throw new ArgumentException("Fail");
            }
            restaurant.Status = @event.Status;
            restaurant.Active = true;
            await _projectionGateway.UpdateFieldAsync(x => x.Id == @event.AggregateId, restaurant, cancellationToken);
        }
    }
}
