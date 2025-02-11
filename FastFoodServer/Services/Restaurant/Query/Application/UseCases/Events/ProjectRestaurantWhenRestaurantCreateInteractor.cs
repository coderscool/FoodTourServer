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
    public class ProjectRestaurantWhenRestaurantCreateInteractor : IInteractor<DomainEvent.RestaurantCreate>
    {
        private readonly IProjectionGateway<Projection.RestaurantDetails> _projectionGateway;
        public ProjectRestaurantWhenRestaurantCreateInteractor(IProjectionGateway<Projection.RestaurantDetails> _projectionGateway ) { }
        public Task InteractAsync(DomainEvent.RestaurantCreate @event, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
