using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ProjectRestaurantWhenRestaurantCreateBillInteractor : IInteractor<DomainEvent.RestaurantCreateBill>
    {
        private readonly IProjectionGateway<Projection.Restaurant> _projectionGateway;
        public ProjectRestaurantWhenRestaurantCreateBillInteractor(IProjectionGateway<Projection.Restaurant> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.RestaurantCreateBill @event, CancellationToken cancellationToken)
        {
            var restaurant = new Projection.Restaurant
            {
                Id = @event.AggregateId,
                RestaurantId = @event.RestaurantId,
                CustomerId = @event.CustomerId,
                DishId = @event.DishId,
                Customer = @event.Customer,
                Price = @event.Price,
                Quantity = @event.Quantity,
                Time = @event.Time,
                Status = @event.Status,
                Date = @event.Date,
            };
            Console.Write(restaurant);
            await _projectionGateway.ReplaceInsertAsync(restaurant, cancellationToken); 
        }
    }
}
