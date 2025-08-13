using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Payment;

namespace Application.UseCases.Queries
{
    public class GetPaymentDetail : IInteractor<Query.GetPaymentByIdQuery, Projection.Payment>
    {
        private readonly IProjectionGateway<Projection.Payment> _projectionGateway;
        public GetPaymentDetail(IProjectionGateway<Projection.Payment> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.Payment?> InteractAsync(Query.GetPaymentByIdQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
