using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CreateDeliveryWhenOrderTransportConsumer : Consumer<SummaryEvent.OrderTransport>
    {
        public CreateDeliveryWhenOrderTransportConsumer(IInteractor<SummaryEvent.OrderTransport> interactor) : base(interactor)
        {
        }
    }
}
