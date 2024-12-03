using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class RevenueUpdateInteractor : IInteractor<DomainEvent.RevenueUpdate>
    {
        private readonly IProjectionGateway<Projection.Statistic>  _projectionGateway;
        public RevenueUpdateInteractor(IProjectionGateway<Projection.Statistic> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.RevenueUpdate @event, CancellationToken cancellationToken)
        {
            var statistic = await _projectionGateway.FindAsync(x => x.Id == @event.AggregateId, cancellationToken);
            if (statistic != null)
            {
                statistic.Revenue = @event.Quantity * @event.Price;
                statistic.NumberMeal += @event.Quantity;
                statistic.NumberOrder += 1;
                await _projectionGateway.UpdateFieldAsync(x => x.Id == @event.AggregateId, statistic, cancellationToken);
            }
        }
    }
}
