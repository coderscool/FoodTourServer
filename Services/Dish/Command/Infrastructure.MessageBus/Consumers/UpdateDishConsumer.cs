using Application.Abstractions;
using Contracts.Services.Dish;
using Infrastructure.MessageBus.Abstractions;

namespace Infrastructure.MessageBus.Consumers
{
    public class UpdateDishConsumer : Consumer<Command.UpdateDish>
    {
        public UpdateDishConsumer(IInteractor<Command.UpdateDish> interactor) : base(interactor)
        {
        }
    }
}
