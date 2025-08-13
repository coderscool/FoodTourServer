using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CompleteDeliveryWhenOrderCompleteConsumer : Consumer<DomainEvent.OrderComplete>
    {
        public CompleteDeliveryWhenOrderCompleteConsumer(IInteractor<DomainEvent.OrderComplete> interactor) : base(interactor)
        {
        }
    }
}
