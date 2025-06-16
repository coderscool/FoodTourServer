using Application.UseCases.Events;
using Contracts.Services.Order;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectOrderItemWhenOrderChangedIConsumer :
        IConsumer<DomainEvent.OrderPlaced>,
        IConsumer<DomainEvent.OrderConfirm>
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
    }
}
