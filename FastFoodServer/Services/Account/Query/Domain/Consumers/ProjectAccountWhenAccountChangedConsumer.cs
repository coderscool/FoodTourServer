using Application.Abstractions;
using Application.UseCases.Events;
using Contracts.Services.Account;
using Infrastructure.EventBus.Abstractions;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectAccountWhenAccountChangedConsumer : IConsumer<DomainEvent.AccountCreate>
    {
        private readonly IProjectAccountWhenAccountChangedInteractor _interactor;
        public ProjectAccountWhenAccountChangedConsumer(IProjectAccountWhenAccountChangedInteractor interactor)
        {
            _interactor = interactor;
        }

        public async Task Consume(ConsumeContext<DomainEvent.AccountCreate> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
