using Application.Abstractions;
using Contracts.Services.Delivery;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class RequireCompleteOrderWhenRequireCompleteDeliveryConsumer : Consumer<DomainEvent.DeliveryRequireComplete>
    {
        public RequireCompleteOrderWhenRequireCompleteDeliveryConsumer(IInteractor<DomainEvent.DeliveryRequireComplete> interactor) : base(interactor)
        {
        }
    }
}
