using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;

namespace Application.UseCases.Queries
{
    public class GetAccountSeller : IInteractor<Query.GetAccountId, Projection.AccountSeller>
    {
        private readonly IProjectionGateway<Projection.AccountSeller> _projectionGateway;
        public GetAccountSeller(IProjectionGateway<Projection.AccountSeller> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.AccountSeller?> InteractAsync(Query.GetAccountId query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
