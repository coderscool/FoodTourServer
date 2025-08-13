using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class PublicOrderTransportWhenOrderConfirmConsumer : Consumer<DomainEvent.OrderConfirm>
    {
        public PublicOrderTransportWhenOrderConfirmConsumer(IInteractor<DomainEvent.OrderConfirm> interactor) : base(interactor)
        {
        }
    }
}
