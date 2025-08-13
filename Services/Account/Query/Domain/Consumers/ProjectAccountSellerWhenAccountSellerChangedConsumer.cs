using Application.UseCases.Events;
using Contracts.Services.Account;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectAccountSellerWhenAccountSellerChangedConsumer : IConsumer<DomainEvent.AccountSellerCreate>
    {
        private readonly IProjectAccountSellerWhenAccountSellerChangedInteractor _interactor;
        public ProjectAccountSellerWhenAccountSellerChangedConsumer(IProjectAccountSellerWhenAccountSellerChangedInteractor interactor)
        {
            _interactor = interactor;
        }

        public async Task Consume(ConsumeContext<DomainEvent.AccountSellerCreate> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
