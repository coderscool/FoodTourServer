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
            Dto.Person Customer, string Name, Dto.Price Price, int Quantity, int Time, string Status, DateTime Date, long Version) : Message, IDomainEvent;
        public record ExpireOrderRestaurant(string AggregateId, long Version) : Message, IDomainEvent;
        public record RestaurantAccept(string AggregateId, long Version) : Message, IDomainEvent;
        public record RestaurantCancel(string AggregateId, long Version) : Message, IDomainEvent;

    }
}
