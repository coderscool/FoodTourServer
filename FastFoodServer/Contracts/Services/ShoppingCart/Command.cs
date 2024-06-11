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
        public record AddCartItem(Guid Id, Guid PersonId, Guid DishId, Dto.Person Person, string Name, byte[] Image, Dto.Price Price, int Amount, string Status, int TimeExpire): Message, ICommand;
    }
}
