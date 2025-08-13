using Application.UseCases.Events;
using Contracts.Services.Account;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectAccountUserWhenAccountUserChangedConsumer : IConsumer<DomainEvent.AccountUserCreate>
    {
        private readonly IProjectAccountUserWhenAccountUserChangedInteractor _interactor;
        public ProjectAccountUserWhenAccountUserChangedConsumer(IProjectAccountUserWhenAccountUserChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public async Task Consume(ConsumeContext<DomainEvent.AccountUserCreate> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
