using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.ShoppingCart
{
    public class Command
    {
        public record AddCartItem(string CustomerId, string RestaurantId, string DishId, List<string> Extra, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note): Message, ICommand;
        public record CheckAndRemoveDishCart(string Id, string CartId) : Message, ICommand;
        public record ChangedQuantityItemCart(string CustomerId, string ItemId, ushort Quantity) : Message, ICommand;
        public record CreateCart(string Id) : Message, ICommand;
        public record CheckOutCart(string CartId, List<string> ChooseId, Dto.DtoPerson Customer, ulong Total, string PaymentMethod) : Message, ICommand;
    }
}
