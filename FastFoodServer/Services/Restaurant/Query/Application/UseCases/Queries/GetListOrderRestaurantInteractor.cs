using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetListOrderRestaurantInteractor : IPagedInteractor<Query.GetListOrderRestaurantQuery, Projection.Restaurant>
    {
        private readonly IProjectionGateway<Projection.Restaurant> _projectionGateway;
        public GetListOrderRestaurantInteractor(IProjectionGateway<Projection.Restaurant> projectionGateway) 
        { 
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Restaurant?>> InteractAsync(Query.GetListOrderRestaurantQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindListAsync(x => x.RestaurantId == query.Id && x.Active == false, cancellationToken);
    }
}
