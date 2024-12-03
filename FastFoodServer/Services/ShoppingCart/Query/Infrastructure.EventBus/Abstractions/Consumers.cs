using Application.Abstractions;
using Contracts.Abstractions.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Abstractions
{
    public abstract class Consumer<TMessage> : IConsumer<TMessage>
    where TMessage : class, IDomainEvent
    {
        private readonly IQueryInteractor<TMessage> _interactor;
        protected Consumer(IQueryInteractor<TMessage> interactor)
        {
            _interactor = interactor;
        }
        public async Task Consume(ConsumeContext<TMessage> context)
            => await _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
