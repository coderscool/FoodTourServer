using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;

namespace Application.UseCases.Queries
{
    public class GetAccountShipper : IInteractor<Query.GetAccountId, Projection.AccountShipper>
    {
        private readonly IProjectionGateway<Projection.AccountShipper> _projectionGateway;
        public GetAccountShipper(IProjectionGateway<Projection.AccountShipper> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.AccountShipper?> InteractAsync(Query.GetAccountId query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
