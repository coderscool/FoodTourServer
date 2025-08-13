using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CompleteOrderConsumer : Consumer<Command.CompleteOrder>
    {
        public CompleteOrderConsumer(IInteractor<Command.CompleteOrder> interactor) : base(interactor)
        {
        }
    }
}
