using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class ChangeCustomerCartConsumer : Consumer<Command.ChangeCustomerCart>
    {
        public ChangeCustomerCartConsumer(IInteractor<Command.ChangeCustomerCart> interactor) : base(interactor)
        {
        }
    }
}
