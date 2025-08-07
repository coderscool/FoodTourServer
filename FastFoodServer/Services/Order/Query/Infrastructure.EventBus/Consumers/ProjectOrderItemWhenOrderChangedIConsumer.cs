using Application.UseCases.Events;
using Contracts.Services.Order;
using MassTransit;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectOrderItemWhenOrderChangedIConsumer :
        IConsumer<DomainEvent.OrderPlaced>,
        IConsumer<DomainEvent.OrderConfirm>,
        IConsumer<DomainEvent.OrderCompleteDish>,
        IConsumer<DomainEvent.OrderRequire>,
        IConsumer<DomainEvent.OrderConfirmRequire>,
        IConsumer<DomainEvent.OrderRequireComplete>,
        IConsumer<DomainEvent.OrderComplete>
    {
        private readonly IProjectOrderItemWhenOrderChangedInteractor _interactor;
        public ProjectOrderItemWhenOrderChangedIConsumer(IProjectOrderItemWhenOrderChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public Task Consume(ConsumeContext<DomainEvent.OrderPlaced> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.OrderConfirm> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.OrderCompleteDish> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.OrderRequire> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.OrderConfirmRequire> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.OrderRequireComplete> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.OrderComplete> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
