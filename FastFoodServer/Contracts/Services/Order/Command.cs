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
        public record AddItemOrder(string Id, string RestaurantId, string CustomerId, string DishId, Dto.Person Restaurant, 
            Dto.Person Customer, string Name, long Price, int Quantity, int Time, bool Status, DateTime Date) : Message, ICommand;

        public record ConfirmOrder(string Id) : Message, ICommand;

        public record UpdateStatus(string Id, bool Status) : Message, ICommand;
    }
}
