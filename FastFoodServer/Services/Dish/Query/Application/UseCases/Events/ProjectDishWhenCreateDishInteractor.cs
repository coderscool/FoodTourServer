using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectDishWhenCreateDishInteractor : IInteractor<DomainEvent.DishCreate>
    {
        private readonly IProjectionGateway<Projection.Dishs> _projectionGateway;
        private readonly IElasticSearchGateway<Projection.Dishs> _elasticSearchGateway;

        public ProjectDishWhenCreateDishInteractor(IProjectionGateway<Projection.Dishs> projectionGateway,
            IElasticSearchGateway<Projection.Dishs> elasticSearchGateway)
        {
            _projectionGateway = projectionGateway;
            _elasticSearchGateway = elasticSearchGateway;
        }

        public async Task InteractAsync(DomainEvent.DishCreate @event, CancellationToken cancellationToken)
        {
            Projection.Dishs dish = new (
                @event.Id, 
                @event.RestaurantId, 
                @event.Dish, 
                @event.Price, 
                @event.Quantity, 
                @event.Search, 
                @event.Version);
            await _projectionGateway.ReplaceInsertAsync(dish, cancellationToken);
            await _elasticSearchGateway.InsertDocumentAsync(dish);
        }
    }
}
