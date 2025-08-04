using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;

namespace Application.UseCases.Queries
{
    public class GetAccountUser : IInteractor<Query.GetAccountId, Projection.AccountUser>
    {
        private readonly IProjectionGateway<Projection.AccountUser> _projectionGateway;
        public GetAccountUser(IProjectionGateway<Projection.AccountUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.AccountUser?> InteractAsync(Query.GetAccountId query, CancellationToken cancellationToken)
            => await _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}