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
    public interface IProjectOrderWhenOrderChangedInteractor : 
        IInteractor<DomainEvent.OrderPlaced>;
    public class ProjectOrderWhenOrderChangedInteractor : IProjectOrderWhenOrderChangedInteractor
    {
        private readonly IProjectionGateway<Projection.Order> _projectionGateway;

        public ProjectOrderWhenOrderChangedInteractor(IProjectionGateway<Projection.Order> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.OrderPlaced @event, CancellationToken cancellationToken)
        {
            Projection.Order order = new (
                @event.Id, 
                @event.CustomerId, 
                @event.Customer, 
                @event.Total,
                @event.Version);

            await _projectionGateway.ReplaceInsertAsync(order, cancellationToken);
        }
    }
}
