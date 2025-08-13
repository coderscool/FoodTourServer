using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Account;
using System.Drawing;

namespace Application.UseCases.Events
{
    public interface IProjectAccountShipperWhenAccountShipperChangedInteractor : IInteractor<DomainEvent.AccountShipperCreate>;
    public class ProjectAccountShipperWhenAccountShipperChangedInteractor : IProjectAccountShipperWhenAccountShipperChangedInteractor
    {
        private readonly IProjectionGateway<Projection.AccountShipper> _projectionGateway;
        public ProjectAccountShipperWhenAccountShipperChangedInteractor(IProjectionGateway<Projection.AccountShipper> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task InteractAsync(DomainEvent.AccountShipperCreate @event, CancellationToken cancellationToken)
        {
            Projection.AccountShipper accounts = new(
                @event.Id,
                @event.Shipper,
                @event.Image,
                @event.Version);

            await _projectionGateway.ReplaceInsertAsync(accounts, cancellationToken);
        }
    }
}
