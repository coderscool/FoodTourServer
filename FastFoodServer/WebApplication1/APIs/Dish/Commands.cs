using Contracts.Services.Dish;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Dish.Validators;

namespace WebApplication1.APIs.Dish
{
    public class Commands
    {
        public record CreateDish(IBus Bus, string RestaurantId, Payloads.CreateDish Payload, CancellationToken CancellationToken)
            : Validatable<CreateDishValidator>, ICommand<Command.CreateDish>
        {
            public Command.CreateDish Command
                => new(RestaurantId, Payload.Dish, Payload.Price, Payload.Quantity, Payload.Search);
        }
    }
}
