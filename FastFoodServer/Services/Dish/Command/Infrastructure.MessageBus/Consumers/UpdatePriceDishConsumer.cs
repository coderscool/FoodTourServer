using Application.Abstractions;
using Contracts.Services.Dish;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdatePriceDishConsumer : Consumer<Command.UpdatePriceDish>
    {
        public UpdatePriceDishConsumer(IInteractor<Command.UpdatePriceDish> interactor) : base(interactor)
        {
        }
    }
}
