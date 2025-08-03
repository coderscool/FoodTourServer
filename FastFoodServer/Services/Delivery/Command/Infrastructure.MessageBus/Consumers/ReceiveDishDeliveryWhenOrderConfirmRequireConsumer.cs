using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class ReceiveDishDeliveryWhenOrderConfirmRequireConsumer : Consumer<DomainEvent.OrderConfirmRequire>
    {
        public ReceiveDishDeliveryWhenOrderConfirmRequireConsumer(IInteractor<DomainEvent.OrderConfirmRequire> interactor) : base(interactor)
        {
        }
    }
}
