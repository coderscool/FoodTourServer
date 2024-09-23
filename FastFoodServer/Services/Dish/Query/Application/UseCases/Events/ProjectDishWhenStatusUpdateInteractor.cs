using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;
using MassTransit.Transports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectDishWhenStatusUpdateInteractor : IInteractor<DomainEvent.QuantityUpdate>
    {
        private readonly IProjectionGateway<Projection.Dish> _projectionGateway;
        public ProjectDishWhenStatusUpdateInteractor(IProjectionGateway<Projection.Dish> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.QuantityUpdate @event, CancellationToken cancellationToken)
        {
            var dish = await _projectionGateway.FindAsync(x => x.Id == @event.AggregateId, cancellationToken);
            dish.Quantity = @event.Quantity;
            await _projectionGateway.UpdateFieldAsync(x => x.Id == @event.AggregateId, dish, cancellationToken);
        }
    }
}
