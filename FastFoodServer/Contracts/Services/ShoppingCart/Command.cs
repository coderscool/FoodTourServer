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
        public record AddCartItem(string CartId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, int Quantity): Message, ICommand;
        public record CheckAndRemoveDishCart(string Id) : Message, ICommand;
        public record IncreaseQuantityCart(string Id, int Quantity) : Message, ICommand;
        public record CreateCart(string CustomerId, Dto.DtoPerson Customer, string Description) : Message, ICommand;
    }
}
