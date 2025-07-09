using Application.Abstractions;
using Application.Services;
using Contracts.Services.Account;
using Domain.Aggregates.Seller;
using Identity = Contracts.Services.Identity;

namespace Application.UseCases.Events
{
    public class CreateAccountSellerWhenSellerRegisterInteractor : IInteractor<Identity.DomainEvent.SellerRegister>
    {
        private readonly IApplicationService _applicationService;
        public CreateAccountSellerWhenSellerRegisterInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.SellerRegister @event, CancellationToken cancellationToken)
        {
            AccountSeller account = new();
            account.Handle(new Command.CreateAccountSeller(@event.Id, @event.Seller, @event.Image, @event.Nation, @event.TimeActive));
            await _applicationService.AppendEventsAsync(account, cancellationToken);
        }
    }
}
