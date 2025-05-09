using Application.UseCases.Events;
using Contracts.Services.ShoppingCart;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectCartWhenCartChangedConsumer 
        : IConsumer<DomainEvent.CartCreate>,
          IConsumer<DomainEvent.CartChangeCustomer>,
          IConsumer<DomainEvent.CartChangeDescription>,
          IConsumer<DomainEvent.CartItemAdd>,
          IConsumer<DomainEvent.CartRemove>
    {
        private readonly IProjectCartWhenCartChangedInteractor _interactor;
        public ProjectCartWhenCartChangedConsumer(IProjectCartWhenCartChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public Task Consume(ConsumeContext<DomainEvent.CartCreate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.CartChangeCustomer> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.CartChangeDescription> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.CartItemAdd> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.CartRemove> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
