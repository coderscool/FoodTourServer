using Contracts.Abstractions.DataTransferObject;
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
        public record AddCartItem(string Id, string RestaurantId, string CustomerId, string DishId, int Amount): Message, ICommand;
        public record CheckAndRemoveDishCart(string Id) : Message, ICommand;
        public record IncreaseQuantityCart(string Id, int Quantity) : Message, ICommand;

    }
}
