using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class ProjectAccountWhenRegisterInteractor : IInteractor<DomainEvent.AccountCreate>
    {
        private readonly IProjectionGateway<Projection.Account> _projectionGateway;
        public ProjectAccountWhenRegisterInteractor(IProjectionGateway<Projection.Account> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.AccountCreate @event, CancellationToken cancellationToken)
        {
            var account = new Projection.Account
            {
                Id = @event.AggregateId,
                Budget = @event.Budget,
            };
            await _projectionGateway.ReplaceInsertAsync(account, cancellationToken);
        }
    }
}
