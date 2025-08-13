using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Delivery;

namespace Application.UseCases.Queries
{
    public class GetDeliveryDetail : IInteractor<Query.GetById, Projection.Delivery>
    {
        private readonly IProjectionGateway<Projection.Delivery> _projectionGateway;
        public GetDeliveryDetail(IProjectionGateway<Projection.Delivery> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }

        public async Task<Projection.Delivery?> InteractAsync(Query.GetById query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
