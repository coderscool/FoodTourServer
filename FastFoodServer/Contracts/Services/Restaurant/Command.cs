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
        public record CreateBillRestaurant(string Id, string RestaurantId, string CustomerId, string DishId, Dto.Person Customer,
            string Name, long Price, int Quantity, int Time, DateTime Date) : Message, ICommand;

        public record ReplyRestaurant(string Id, bool Status) : Message, ICommand;

    }
}
