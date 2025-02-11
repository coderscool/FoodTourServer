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
        private readonly IElasticClient _elasticClient;

        public ProjectDishWhenCreateDishInteractor(IProjectionGateway<Projection.Dishs> projectionGateway,
            IElasticClient elasticClient)
        {
            _projectionGateway = projectionGateway;
            _elasticClient = elasticClient;
        }

        public async Task InteractAsync(DomainEvent.DishCreate @event, CancellationToken cancellationToken)
        {
            var dish = new Projection.Dishs(@event.AggregateId, @event.RestaurantId, @event.Dish, @event.Price, @event.Quantity, @event.Search);
            Console.WriteLine(@event.AggregateId);
            await _projectionGateway.ReplaceInsertAsync(dish, cancellationToken);
            //await _elasticClient.IndexDocumentAsync(dish);
        }
    }
}
