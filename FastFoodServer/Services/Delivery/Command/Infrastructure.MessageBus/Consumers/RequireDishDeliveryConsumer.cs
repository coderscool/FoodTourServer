using Application.Abstractions;
using Contracts.Services.Delivery;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class RequireDishDeliveryConsumer : Consumer<Command.RequireDishDelivery>
    {
        public RequireDishDeliveryConsumer(IInteractor<Command.RequireDishDelivery> interactor) : base(interactor)
        {
        }
    }
}
