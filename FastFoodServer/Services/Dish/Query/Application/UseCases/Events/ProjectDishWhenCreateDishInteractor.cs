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
                Name = @event.Dish.Name,
                Image = @event.Image,
                Location = @event.Dish.Location,
                Category = @event.Search.Category,
                Nation = @event.Search.Nation,
                Cost = @event.Price.Cost,
                Discount = @event.Price.Discount,
                Rate = @event.Rate.Point
            };
            Console.WriteLine(@event.Image);
            //await _projectionGateway.ReplaceInsertAsync(listAccountUser, cancellationToken);
        }
    }
}
