using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class Command
    {
        public record CreateBillRestaurant(string OrderId, string RestaurantId, string CustomerId, string DishId, Dto.Person Customer,
            string Name, long Price, int Quantity, int Time, bool Status, DateTime Date) : Message, ICommand;

        public record RestaurantAccept(string Id) : Message, ICommand;

        public record RejectRestaurant(string Id) : Message, ICommand;
    }
}
