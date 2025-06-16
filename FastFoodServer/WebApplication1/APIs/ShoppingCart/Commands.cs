using Contracts.DataTransferObject;
using Contracts.Services.ShoppingCart;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.ShoppingCart.Validators;

namespace WebApplication1.APIs.ShoppingCart
{
    public class Commands
    {
        public record CreateCart(IBus Bus, Payloads.CreateCartPayload Payload, CancellationToken CancellationToken)
            : Validatable<CreateCartValidator>, ICommand<Command.CreateCart>
        {
            public Command.CreateCart Command => new(Payload.CustomerId, Payload.Customer, Payload.Description);
        }

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

        public record RemoveCart(IBus Bus, string Id, CancellationToken CancellationToken) 
            : Validatable<RemoveCartValidator>, ICommand<Command.RemoveCart>
        {
            public Command.RemoveCart Command => new(Id);
        }

        public record ChangedQuantityItemCart(IBus Bus, string ItemId, string CartId, ushort Quantity, CancellationToken CancellationToken) 
            : Validatable<ChangedQuantityItemCartValidator>, ICommand<Command.ChangedQuantityItemCart>
        {
            public Command.ChangedQuantityItemCart Command => new(ItemId, CartId, Quantity);
        }

        public record ChangeDescriptionCart(IBus Bus, string Id, string Description, CancellationToken CancellationToken) 
            : Validatable<ChangeDescriptionCartValidator>, ICommand<Command.ChangeDescriptionCart>
        {
            public Command.ChangeDescriptionCart Command => new(Id, Description);
        }

        public record ChangeCustomerCart(IBus Bus, string Id, Dto.DtoPerson Customer, CancellationToken CancellationToken) 
            : Validatable<ChangeCustomerCartValidator>, ICommand<Command.ChangeCustomerCart>
        {
            public Command.ChangeCustomerCart Command => new(Id, Customer);
        }

        public record ChooseItemCart(IBus Bus, string CartId, string ItemId, bool Choose, CancellationToken CancellationToken)
            : Validatable<ChangedPaymentCartValidator>, ICommand<Command.ChooseItemCart>
        {
            public Command.ChooseItemCart Command => new(CartId, ItemId, Choose);
        }

        public record ChangedPaymentCart(IBus Bus, string CartId, string Payment, CancellationToken CancellationToken)
            : Validatable<ChangedPaymentCartValidator>, ICommand<Command.ChangedPaymentCart>
        {
            public Command.ChangedPaymentCart Command => new(CartId, Payment);
        }
    }
}
