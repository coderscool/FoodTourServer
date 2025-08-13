using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;
using Contracts.Services.Order;

namespace Application.UseCases.Queries
{
    public class GetListOrderSeller : IPagedInteractor<Query.GetOrderSellerQuery, Projection.OrderGroup>
    {
        private readonly IProjectionGateway<Projection.OrderGroup> _projectionGateway;
        public GetListOrderSeller(IProjectionGateway<Projection.OrderGroup> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }

        public async ValueTask<IPagedResult<Projection.OrderGroup>> InteractAsync(Query.GetOrderSellerQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.ListAsync(x => x.RestaurantId == query.Id, query.Paging, cancellationToken);
    }
}
