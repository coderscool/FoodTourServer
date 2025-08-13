using Application.Abstractions;
using Contracts.Services.Delivery;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class RequireCompleteDeliveryConsumer : Consumer<Command.RequireCompleteDelivery>
    {
        public RequireCompleteDeliveryConsumer(IInteractor<Command.RequireCompleteDelivery> interactor) : base(interactor)
        {
        }
    }
}
