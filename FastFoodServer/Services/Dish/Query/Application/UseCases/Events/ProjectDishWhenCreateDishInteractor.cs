using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;
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

        public ProjectDishWhenCreateDishInteractor(IProjectionGateway<Projection.Dish> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.DishCreate @event, CancellationToken cancellationToken)
        {
            var listAccountUser = new Projection.Dish
            {
                Id = @event.AggregateId,
                PersonId = @event.PersonId,
                Person = @event.Person,
                Name = @event.Name,
                Image = @event.Image,
                Category = @event.Search.Category,
                Nation = @event.Search.Nation,
                Cost = @event.Price.Cost,
                Discount = @event.Price.Discount,
                Rate = @event.Rate.Point,
                Sell = 0
            };
            Console.WriteLine(@event.AggregateId);
            await _projectionGateway.ReplaceInsertAsync(listAccountUser, cancellationToken);
        }
    }
}
