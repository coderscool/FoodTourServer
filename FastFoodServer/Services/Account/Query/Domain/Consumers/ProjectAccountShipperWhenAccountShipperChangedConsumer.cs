using Application.UseCases.Events;
using Contracts.Services.Account;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectAccountShipperWhenAccountShipperChangedConsumer : IConsumer<DomainEvent.AccountShipperCreate>
    {
        private readonly IProjectAccountShipperWhenAccountShipperChangedInteractor _interactor;
        public ProjectAccountShipperWhenAccountShipperChangedConsumer(IProjectAccountShipperWhenAccountShipperChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public async Task Consume(ConsumeContext<DomainEvent.AccountShipperCreate> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
