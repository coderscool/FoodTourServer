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
    public class GetDishDetailInteractor : IInteractor<Query.DishDetailsById, Projection.Dishs>
    {
        private readonly IProjectionGateway<Projection.Dishs> _projectionGateway;

        public GetDishDetailInteractor(IProjectionGateway<Projection.Dishs> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.Dishs?> InteractAsync(Query.DishDetailsById query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
