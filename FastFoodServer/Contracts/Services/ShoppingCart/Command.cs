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
        public record AddCartItem(string CartId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note): Message, ICommand;
        public record CheckAndRemoveDishCart(string Id, string CartId) : Message, ICommand;
        public record RemoveCart(string CartId) : Message, ICommand;
        public record ChangedQuantityItemCart(string ItemId, string CartId, ushort Quantity) : Message, ICommand;
        public record CreateCart(string CustomerId, Dto.DtoPerson Customer, string Description) : Message, ICommand;
        public record ChangeDescriptionCart(string Id, string Description) : Message, ICommand;
        public record ChangeCustomerCart(string Id, Dto.DtoPerson Customer) : Message, ICommand;
    }
}
