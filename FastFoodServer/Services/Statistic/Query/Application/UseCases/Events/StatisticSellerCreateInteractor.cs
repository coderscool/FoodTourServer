using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Statistic;

namespace Application.UseCases.Events
{
    public class StatisticSellerCreateInteractor : IInteractor<DomainEvent.StatisticSellerCreate>
    {
        private readonly IProjectionGateway<Projection.StatisticSeller> _projectionGateway;
        public StatisticSellerCreateInteractor(IProjectionGateway<Projection.StatisticSeller> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.StatisticSellerCreate @event, CancellationToken cancellationToken)
        {
            Projection.StatisticSeller statictic = new (
                @event.Id,
                @event.NumberOrder,
                @event.NumberMeal,
                @event.NumberDish,
                @event.Revenue,
                @event.NumberRate,
                @event.EvaluateAvg,
                @event.Version
            );


            await _projectionGateway.ReplaceInsertAsync(statictic, cancellationToken);
        }
    }
}
