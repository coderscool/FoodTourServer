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
    public class GetListDishRestaurantInteractor : IPagedInteractor<Query.DishRestaurantQuery, Projection.Dishs>
    {
        private readonly IProjectionGateway<Projection.Dishs> _projectionGateway;
        public GetListDishRestaurantInteractor(IProjectionGateway<Projection.Dishs> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Dishs?>> InteractAsync(Query.DishRestaurantQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindPaginatonAsync(x => x.PersonId == query.Id, query.Page, query.Size, cancellationToken);
    }
}
