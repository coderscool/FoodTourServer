using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    public class Command
    {
        public record AddCartItem(string CustomerId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note): Message, ICommand;
        public record CheckAndRemoveDishCart(string Id, string CartId) : Message, ICommand;
        public record ChangedQuantityItemCart(string CustomerId, string ItemId, ushort Quantity) : Message, ICommand;
        public record CreateCart(string Id) : Message, ICommand;
        public record CheckOutCart(string CartId, List<string> ChooseId, Dto.DtoPerson Customer, ulong Total, string PaymentMethod, bool IsSuccess) : Message, ICommand;
    }
}
