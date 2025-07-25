using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateOrderDeliveryWhenOrderCompleteDishConsumer : Consumer<DomainEvent.OrderCompleteDish>
    {
        public UpdateOrderDeliveryWhenOrderCompleteDishConsumer(IInteractor<DomainEvent.OrderCompleteDish> interactor) : base(interactor)
        {
        }
    }
}
