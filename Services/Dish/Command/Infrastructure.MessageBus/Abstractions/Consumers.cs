using Application.Abstractions;
using Contracts.Abstractions.Messages;
using MassTransit;

namespace Infrastructure.MessageBus.Abstractions
{
    public abstract class Consumer<TMessage> : IConsumer<TMessage>
        where TMessage : class, IMessage
    {
        private readonly IInteractor<TMessage> _interactor;

        protected Consumer(IInteractor<TMessage> interactor)
            => _interactor = interactor;

        public async Task Consume(ConsumeContext<TMessage> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
