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
    public class ProjectCartItemWhenCartItemChangedConsumer : 
        IConsumer<DomainEvent.CartItemAdd>,
        IConsumer<DomainEvent.CartRemove>,
        IConsumer<DomainEvent.CartItemChangedQuantity>
    {
        private readonly IProjectCartItemWhenCartItemChangedInteractor _interactor;
        public ProjectCartItemWhenCartItemChangedConsumer(IProjectCartItemWhenCartItemChangedInteractor interactor)
        {
            _interactor = interactor;
        }
        public Task Consume(ConsumeContext<DomainEvent.CartItemAdd> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.CartRemove> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.CartItemChangedQuantity> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
