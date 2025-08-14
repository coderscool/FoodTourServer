using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Statistic;

namespace Application.UseCases.Queries
{
    public class GetStatisticDetail : IInteractor<Query.GetById, Projection.StatisticSeller>
    {
        private readonly IProjectionGateway<Projection.StatisticSeller> _projectionGateway;
        public GetStatisticDetail(IProjectionGateway<Projection.StatisticSeller> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.StatisticSeller?> InteractAsync(Query.GetById query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
                
    }
}
