using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class Command
    {
        public record CreateRestaurant(string UserId, Dto.DtoPerson Restaurant, Dto.DtoSearch Search) : Message, ICommand;
        public record CreateBillRestaurant(string Id, string RestaurantId, string CustomerId, string DishId, Dto.DtoPerson Customer,
            string Name, long Price, int Quantity, int Time, DateTime Date) : Message, ICommand;

        public record ReplyRestaurant(string Id, bool Status) : Message, ICommand;

    }
}
