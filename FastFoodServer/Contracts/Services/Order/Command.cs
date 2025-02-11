using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Order
{
    public class Command
    {
        public record AddItemOrder(string Id, string RestaurantId, string CustomerId, string DishId, Dto.DtoPerson Restaurant, 
            Dto.DtoPerson Customer, string Name, long Price, int Quantity, int Time, DateTime Date) : Message, ICommand;

        public record ConfirmOrder(string Id) : Message, ICommand;

        public record UpdateStatus(string Id, bool Status) : Message, ICommand;
    }
}
