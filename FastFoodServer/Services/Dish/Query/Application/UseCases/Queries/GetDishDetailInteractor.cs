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
    public class GetDishDetailInteractor : IInteractor<Query.DishDetailQuery, Projection.Dish>
    {
        private readonly IProjectionGateway<Projection.Dish> _projectionGateway;

        public GetDishDetailInteractor(IProjectionGateway<Projection.Dish> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.Dish?> InteractAsync(Query.DishDetailQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
