using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class DomainEvent
    {
        public record RestaurantCreateBill(string AggregateId, string OrderId, string RestaurantId, string CustomerId, string DishId, 
            Dto.Person Customer, string Name, long Price, int Quantity, int Time, bool Status, DateTime Date, long Version) : Message, IDomainEvent;
        public record ExpireOrderRestaurant(string AggregateId, long Version) : Message, IDomainEvent;
        public record RestaurantReply(string AggregateId, string OrderId, string RestaurantId, string CustomerId, long Price, bool Status, long Version) : Message, IDomainEvent;

    }
}
