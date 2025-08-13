using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateNumberOrderWhenOrderTransportConsumer : Consumer<SummaryEvent.OrderTransport>
    {
        public UpdateNumberOrderWhenOrderTransportConsumer(IInteractor<SummaryEvent.OrderTransport> interactor) : base(interactor)
        {
        }
    }
}
