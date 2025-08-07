using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class RequestPaymentWhenOrderPlacedConsumer : Consumer<DomainEvent.OrderPlaced>
    {
        public RequestPaymentWhenOrderPlacedConsumer(IInteractor<DomainEvent.OrderPlaced> interactor) : base(interactor)
        {
        }
    }
}
