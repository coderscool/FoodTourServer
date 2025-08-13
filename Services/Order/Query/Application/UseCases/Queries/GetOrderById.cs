using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Order;

namespace Application.UseCases.Queries
{
    public class GetOrderById : IInteractor<Query.GetOrderByIdQuery, Projection.OrderGroup>
    {
        private readonly IProjectionGateway<Projection.OrderGroup> _projectionGateway;
        public GetOrderById(IProjectionGateway<Projection.OrderGroup> projectionGateway) 
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.OrderGroup?> InteractAsync(Query.GetOrderByIdQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
