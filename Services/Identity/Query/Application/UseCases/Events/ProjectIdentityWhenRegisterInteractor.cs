using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Identity;

namespace Application.UseCases.Events
{
    public interface IProjectIdentityWhenRegisterInteractor : 
        IInteractor<DomainEvent.UserRegister>,
        IInteractor<DomainEvent.SellerRegister>,
        IInteractor<DomainEvent.ShipperRegister>;
    public class ProjectIdentityWhenRegisterInteractor : IProjectIdentityWhenRegisterInteractor
    {
        private readonly IProjectionGateway<Projection.Identity> _projectionGateway;

        public ProjectIdentityWhenRegisterInteractor(IProjectionGateway<Projection.Identity> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }

        public async Task InteractAsync(DomainEvent.UserRegister @event, CancellationToken cancellationToken)
        {
            var user = new Projection.Identity(@event.Id, @event.UserName, @event.PassWord, @event.Role, "", @event.Version);
            Console.WriteLine(user);
            await _projectionGateway.ReplaceInsertAsync(user, cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.SellerRegister @event, CancellationToken cancellationToken)
        {
            var user = new Projection.Identity(@event.Id, @event.UserName, @event.PassWord, @event.Role, "", @event.Version);
            Console.WriteLine(user);
            await _projectionGateway.ReplaceInsertAsync(user, cancellationToken);
        }

        public async Task InteractAsync(DomainEvent.ShipperRegister @event, CancellationToken cancellationToken)
        {
            var user = new Projection.Identity(@event.Id, @event.UserName, @event.PassWord, @event.Role, "", @event.Version);
            Console.WriteLine(user);
            await _projectionGateway.ReplaceInsertAsync(user, cancellationToken);
        }
    }
}
