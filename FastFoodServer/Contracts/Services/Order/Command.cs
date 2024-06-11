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
        public record AddItemOrder(string Id, string PersonId, string DishId, Dto.Person Person,
            string Name, string Image, Dto.Price Price, int Amount, int Time, DateTime Date) : Message, ICommand;
    }
}
