using Application.Abstractions;
using Contracts.Abstractions.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Abstractions
{
    public abstract class Consumers<TMessage> : IConsumer<TMessage>
    where TMessage : class, IMessage
    {
        private readonly IInteractor<TMessage> _interactor;

        protected Consumers(IInteractor<TMessage> interactor)
            => _interactor = interactor;

        public async Task Consume(ConsumeContext<TMessage> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
