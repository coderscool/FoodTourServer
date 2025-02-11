using Contracts.Services.Restaurant;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Restaurants.Validators;

namespace WebApplication1.APIs.Restaurants
{
    public class Commands
    {
        public record CreateRestaurant(IBus Bus, string UserId, Payloads.CreateRestaurant Payload, CancellationToken CancellationToken)
            : Validatable<CreateRestaurantValidator>, ICommand<Command.CreateRestaurant>
        {
            public Command.CreateRestaurant Command 
                => new(UserId, Payload.Restaurant, Payload.Search);
        }
    }
}
