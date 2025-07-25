using MassTransit;
using Application.UseCases.Events;
using Contracts.Services.Delivery;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectDeliveryWhenDeliveryChangedConsumer : 
        IConsumer<DomainEvent.DeliveryCreate>,
        IConsumer<DomainEvent.DeliveryUpdateOrder>,
        IConsumer<DomainEvent.DeliveryAddShipper>
    {
        private readonly IProjectDeliveryWhenDeliveryChangedInteractor _interactor;
        public ProjectDeliveryWhenDeliveryChangedConsumer(IProjectDeliveryWhenDeliveryChangedInteractor interactor) 
        {
            _interactor = interactor;
        }

        public Task Consume(ConsumeContext<DomainEvent.DeliveryCreate> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.DeliveryUpdateOrder> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);

        public Task Consume(ConsumeContext<DomainEvent.DeliveryAddShipper> context)
            => _interactor.InteractAsync(context.Message, context.CancellationToken);
    }
}
