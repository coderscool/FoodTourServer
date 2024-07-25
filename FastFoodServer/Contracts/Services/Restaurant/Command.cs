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
            string Name, Dto.Price Price, int Amount, int Time, string Status, DateTime Date) : Message, ICommand;
    }
}
