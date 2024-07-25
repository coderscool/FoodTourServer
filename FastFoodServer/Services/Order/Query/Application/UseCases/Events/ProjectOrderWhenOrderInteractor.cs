using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectOrderWhenOrderInteractor : IInteractor<DomainEvent.OrderAddItem>
    {
        private readonly IProjectionGateway<Projection.Order> _projectionGateway;

        public ProjectOrderWhenOrderInteractor(IProjectionGateway<Projection.Order> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.OrderAddItem @event, CancellationToken cancellationToken)
        {
            var listAccountUser = new Projection.Order
            {
                Id = @event.AggregateId,
                RestaurantId = @event.RestaurantId,
                CustomerId = @event.CustomerId,
                DishId = @event.DishId,
                Restaurant = @event.Restaurant,
                Customer = @event.Customer,
                Name = @event.Name,
                Price = @event.Price,
                Status = @event.Status,
                Amount = @event.Quantity,
                Date = @event.Date
            };
            Console.WriteLine(@event.AggregateId);
            await _projectionGateway.ReplaceInsertAsync(listAccountUser, cancellationToken);
        }
    }
}
