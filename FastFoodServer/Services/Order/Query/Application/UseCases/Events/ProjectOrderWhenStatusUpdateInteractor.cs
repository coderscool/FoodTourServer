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
    public class ProjectOrderWhenStatusUpdateInteractor : IInteractor<DomainEvent.StatusUpdate>
    {
        private readonly IProjectionGateway<Projection.Order> _projectionGateway;
        public ProjectOrderWhenStatusUpdateInteractor(IProjectionGateway<Projection.Order> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.StatusUpdate @event, CancellationToken cancellationToken)
        {
            var order = await _projectionGateway.FindAsync(x => x.Id == @event.AggregateId, cancellationToken);
            if (order == null)
            {
                throw new ArgumentException("Fail");
            }
            order.Status = @event.Status;
            order.Active = true;
            await _projectionGateway.UpdateFieldAsync(x => x.Id == @event.AggregateId, order, cancellationToken);
        }
    }
}
