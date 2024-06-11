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
    public class GetListDishInteractor : IPagedInteractor<Query.DishDetailQuery, Projection.Dish>
    {
        private readonly IProjectionGateway<Projection.Dish> _projectionGateway;

        public GetListDishInteractor(IProjectionGateway<Projection.Dish> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Dish?>> InteractAsync(Query.DishDetailQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindSellAsync(cancellationToken);
    }
}
