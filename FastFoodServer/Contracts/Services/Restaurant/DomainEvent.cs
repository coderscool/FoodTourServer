using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class DomainEvent
    {
        public record RestaurantCreateBill(string AggregateId, string RestaurantId, string CustomerId, string DishId, 
            Dto.DtoPerson Customer, string Name, long Price, int Quantity, int Time, bool Status, bool Active, DateTime Date, long Version) : Message, IDomainEvent;
        public record RestaurantCreate(string AggregateId, string UserId, Dto.DtoPerson Restaurant, Dto.DtoSearch Search, long Version) : Message, IDomainEvent;
        public record ExpireOrderRestaurant(string AggregateId, long Version) : Message, IDomainEvent;
        public record RestaurantReply(string AggregateId, string RestaurantId, string CustomerId, string DishId, long Price, int Quantity, bool Status, long Version) : Message, IDomainEvent;

    }
}
