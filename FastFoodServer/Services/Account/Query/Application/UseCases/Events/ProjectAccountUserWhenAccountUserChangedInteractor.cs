using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;

namespace Application.UseCases.Events
{
    public interface IProjectAccountUserWhenAccountUserChangedInteractor : IInteractor<DomainEvent.AccountUserCreate>;
    public class ProjectAccountUserWhenAccountUserChangedInteractor : IProjectAccountUserWhenAccountUserChangedInteractor
    {
        private readonly IProjectionGateway<Projection.AccountUser> _projectionGateway;
        public ProjectAccountUserWhenAccountUserChangedInteractor(IProjectionGateway<Projection.AccountUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.AccountUserCreate @event, CancellationToken cancellationToken)
        {
            Projection.AccountUser accounts = new(
                @event.Id,
                @event.Name,
                @event.Image,
                @event.Version);

            await _projectionGateway.ReplaceInsertAsync(accounts, cancellationToken);
        }
    }
}
