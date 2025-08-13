using Application.Abstractions;
using Application.Services;
using Contracts.Services.Account;
using Domain.Aggregates.Shipper;
using Identity = Contracts.Services.Identity;

namespace Application.UseCases.Events
{
    internal class CreateAccountShipperWhenShipperRegisterInteractor : IInteractor<Identity.DomainEvent.ShipperRegister>
    {
        private readonly IApplicationService _applicationService;
        public CreateAccountShipperWhenShipperRegisterInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.ShipperRegister @event, CancellationToken cancellationToken)
        {
            AccountShipper account = new();
            account.Handle(new Command.CreateAccountShipper(@event.Id, @event.Shipper, @event.Image));
            await _applicationService.AppendEventsAsync(account, cancellationToken);
        }
    }
}
