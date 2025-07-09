using Application.Abstractions;
using Application.Services;
using Identity = Contracts.Services.Identity;
using Contracts.Services.Account;
using Domain.Aggregates.User;

namespace Application.UseCases.Events
{
    public class CreateAccountUserWhenUserRegisterInteractor : IInteractor<Identity.DomainEvent.UserRegister>
    {
        private readonly IApplicationService _applicationService;
        public CreateAccountUserWhenUserRegisterInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.UserRegister @event, CancellationToken cancellationToken)
        {
            AccountUser account = new();
            account.Handle(new Command.CreateAccountUser(@event.Id, @event.Name, @event.Image));
            await _applicationService.AppendEventsAsync(account, cancellationToken);
        }
    }
}
