using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;
using Contracts.Services.Delivery;

namespace Application.UseCases.Queries
{
    public class GetListDelivery : IPagedInteractor<Query.GetList, Projection.Delivery>
    {
        private readonly IProjectionGateway<Projection.Delivery> _projectionGateway;
        public GetListDelivery(IProjectionGateway<Projection.Delivery> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async ValueTask<IPagedResult<Projection.Delivery>> InteractAsync(Query.GetList query, CancellationToken cancellationToken)
            => await _projectionGateway.ListAsync(x => x.Status == "Pendding", query.Paging, cancellationToken);    
    }
}
