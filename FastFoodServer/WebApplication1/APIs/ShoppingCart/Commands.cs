using Contracts.Services.ShoppingCart;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.ShoppingCart.Validators;

namespace WebApplication1.APIs.ShoppingCart
{
    public class Commands
    {
        public record AddCartItem(IBus Bus, string CartId, Payloads.AddItemCartPayload Payload, CancellationToken CancellationToken)
            : Validatable<AddItemCartValidator>, ICommand<Command.AddCartItem>
        {
            public Command.AddCartItem Command => new(CartId, Payload.RestaurantId, Payload.DishId, Payload.Restaurant,
                Payload.Dish, Payload.Price, Payload.Quantity, Payload.Note);
        }

        public record CheckAndRemoveDishCart(IBus Bus, string Id, string CartId, CancellationToken CancellationToken)
            : Validatable<CheckAndRemoveDishCartValidator>, ICommand<Command.CheckAndRemoveDishCart>
        {
            public Command.CheckAndRemoveDishCart Command => new(Id, CartId);
        }

        public record ChangedQuantityItemCart(IBus Bus, string ItemId, string CartId, ushort Quantity, CancellationToken CancellationToken) 
            : Validatable<ChangedQuantityItemCartValidator>, ICommand<Command.ChangedQuantityItemCart>
        {
            public Command.ChangedQuantityItemCart Command => new(ItemId, CartId, Quantity);
        }
    }
}
