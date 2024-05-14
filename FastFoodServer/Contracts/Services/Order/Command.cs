using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Order
{
    public class Command
    {
        public record Order(Guid Id, Dto.Dish Dish, byte[] Image, Dto.Price Price, int Amount, int Date) : Message, ICommand;
    }
}
