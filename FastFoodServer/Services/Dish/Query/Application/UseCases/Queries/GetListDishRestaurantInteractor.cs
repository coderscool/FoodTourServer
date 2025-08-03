using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;

namespace Application.UseCases.Queries
{
    public class GetListDishRestaurantInteractor : IFindInteractor<Query.DishRestaurantQuery, Projection.Dishs>
    {
        private readonly IProjectionGateway<Projection.Dishs> _projectionGateway;
        public GetListDishRestaurantInteractor(IProjectionGateway<Projection.Dishs> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Dishs>> InteractAsync(Query.DishRestaurantQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.ListAsync(x => x.RestaurantId == query.Id & x.Hidden == false, cancellationToken);
    }
}
