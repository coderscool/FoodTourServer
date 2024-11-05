using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Command
    {
        public record CreateDish(string PersonId, string Name, string Image, long Price, int Quantity, Dto.Search Search) : Message, ICommand;
        public record UpdateQuantity(string Id, int Quantity) : Message, ICommand;
    }
}
