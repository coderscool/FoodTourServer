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
    public class StatisticCreateInteractor : IInteractor<DomainEvent.StatisticCreate>
    {
        private readonly IProjectionGateway<Projection.Statistic> _projectionGateway;
        public StatisticCreateInteractor(IProjectionGateway<Projection.Statistic> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.StatisticCreate @event, CancellationToken cancellationToken)
        {
            var statictic = new Projection.Statistic
            {
                Id = @event.AggregateId,
                NumberOrder = @event.NumberOrder,
                NumberMeal = @event.NumberMeal,
                NumberDish = @event.NumberDish,
                Revenue = @event.Revenue,
                NumberRate = @event.NumberRate,
                EvaluateAvg = @event.EvaluateAvg,
            };

            await _projectionGateway.ReplaceInsertAsync(statictic, cancellationToken);
        }
    }
}
