using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;
using Contracts.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetListRestaurantItemsInteractor : IPagedInteractor<Query.ListRestaurantItems, Projection.User>
    {
        private readonly IProjectionGateway<Projection.User> _projectionGateway;
        public GetListRestaurantItemsInteractor(IProjectionGateway<Projection.User> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }
        public async ValueTask<IPagedResult<Projection.User>> InteractAsync(Query.ListRestaurantItems query, CancellationToken cancellationToken)
            => await _projectionGateway.ListAsync(query.Paging, cancellationToken);
    }
}
