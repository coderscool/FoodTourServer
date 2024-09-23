using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetBudgetAccountInteractor : IInteractor<Query.GetAccountId, Projection.Account>
    {
        private readonly IProjectionGateway<Projection.Account> _projectionGateway;
        public GetBudgetAccountInteractor(IProjectionGateway<Projection.Account> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public Task<Projection.Account?> InteractAsync(Query.GetAccountId query, CancellationToken cancellationToken)
            => _projectionGateway.FindAsync(x => x.Id == query.Id, cancellationToken);
    }
}
