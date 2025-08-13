using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class CompleteDishOrderConsumer : Consumer<Command.CompleteDishOrder>
    {
        public CompleteDishOrderConsumer(IInteractor<Command.CompleteDishOrder> interactor) : base(interactor)
        {
        }
    }
}
