using Application.Abstractions;
using Application.UseCases.Events;
using Contracts.Services.Order;
using Infrastructure.EventBus.Abstractions;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectOrderWhenOrderChangedConsumer :
        IConsumer<DomainEvent.OrderPlaced>
    {
        private readonly IProjectOrderWhenOrderChangedInteractor _interactor;
        public ProjectOrderWhenOrderChangedConsumer(IProjectOrderWhenOrderChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public Task Consume(ConsumeContext<DomainEvent.OrderPlaced> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
