using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetListDishRestaurantInteractor : IPagedInteractor<Query.DishRestaurantQuery, Projection.Dish>
    {
        private readonly IProjectionGateway<Projection.Dish> _projectionGateway;
        public GetListDishRestaurantInteractor(IProjectionGateway<Projection.Dish> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Dish?>> InteractAsync(Query.DishRestaurantQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindPaginatonAsync(x => x.PersonId == query.Id, query.Page, query.Size, cancellationToken);
    }
}
