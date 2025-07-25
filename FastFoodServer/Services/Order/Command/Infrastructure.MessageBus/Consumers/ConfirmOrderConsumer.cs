using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class ConfirmOrderConsumer : Consumer<Command.ConfirmOrder?>
    {
        public ConfirmOrderConsumer(IInteractor<Command.ConfirmOrder?> interactor) : base(interactor)
        {
        }
    }
}
