using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Command
    {
        public record CreateDish(string RestaurantId, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search) : Message, ICommand;
        public record UpdateQuantity(string Id, int Quantity) : Message, ICommand;
    }
}
