using Application.Abstractions;
using Contracts.Services.Delivery;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class AddShipperDeliveryConsumer : Consumer<Command.AddShipperDelivery>
    {
        public AddShipperDeliveryConsumer(IInteractor<Command.AddShipperDelivery> interactor) : base(interactor)
        {
        }
    }
}
