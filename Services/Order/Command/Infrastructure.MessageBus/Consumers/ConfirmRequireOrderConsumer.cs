using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class ConfirmRequireOrderConsumer : Consumer<Command.ConfirmRequireOrder>
    {
        public ConfirmRequireOrderConsumer(IInteractor<Command.ConfirmRequireOrder> interactor) : base(interactor)
        {
        }
    }
}
