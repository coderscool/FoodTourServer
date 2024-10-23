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
        private readonly IProjectionGateway<Projection.Dish> _projectionGateway;
        private readonly IElasticClient _elasticClient;

        public ProjectDishWhenCreateDishInteractor(IProjectionGateway<Projection.Dish> projectionGateway,
            IElasticClient elasticClient)
        {
            _projectionGateway = projectionGateway;
            _elasticClient = elasticClient;
        }

        public async Task InteractAsync(DomainEvent.DishCreate @event, CancellationToken cancellationToken)
        {
            var listAccountUser = new Projection.Dish
            {
                Id = @event.AggregateId,
                PersonId = @event.PersonId,
                Name = @event.Name,
                Image = @event.Image,
                Category = @event.Search.Category,
                Nation = @event.Search.Nation,
                Cost = @event.Price,
                Discount = 0,
                Rate = @event.Rate.Point,
                Quantity = @event.Quantity
            };
            Console.WriteLine(@event.AggregateId);
            await _projectionGateway.ReplaceInsertAsync(listAccountUser, cancellationToken);
            await _elasticClient.IndexDocumentAsync(listAccountUser);
        }
    }
}
