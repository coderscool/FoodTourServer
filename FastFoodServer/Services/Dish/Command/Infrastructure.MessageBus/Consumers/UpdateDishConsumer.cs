using Application.Abstractions;
using Contracts.Services.Dish;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateDishConsumer : Consumer<Command.UpdatePriceDish>
    {
        public UpdateDishConsumer(IInteractor<Command.UpdatePriceDish> interactor) : base(interactor)
        {
        }
    }
}
