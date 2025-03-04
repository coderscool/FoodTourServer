using Application.Abstractions;
using Application.Services;
using Identity = Contracts.Services.Identity;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Services.Account;

namespace Application.UseCases.Events
{
    public class CreateAccountWhenRegisterInteractor : IInteractor<Identity.DomainEvent.RegisterEvent>
    {
        private readonly IApplicationService _applicationService;
        public CreateAccountWhenRegisterInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Identity.DomainEvent.RegisterEvent @event, CancellationToken cancellationToken)
        {
            Account account = new();
            account.Handle(new Command.CreateAccount(@event.Id, @event.Person));
            await _applicationService.AppendEventsAsync(account, cancellationToken);
        }
    }
}
