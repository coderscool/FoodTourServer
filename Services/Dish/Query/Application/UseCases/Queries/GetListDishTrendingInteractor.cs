using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;

namespace Application.UseCases.Queries
{
    public class GetListDishTrendingInteractor : IFindInteractor<Query.ListDishTredingQuery, Projection.Dishs>
    {
        private readonly IProjectionGateway<Projection.Dishs> _projectionGateway;
        public GetListDishTrendingInteractor(IProjectionGateway<Projection.Dishs> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Dishs>> InteractAsync(Query.ListDishTredingQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.SortAsync(x => x.Hidden == false, cancellationToken);
    }
}
