using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class DomainEvent
    {
        public record DishCreate(string AggregateId, string RestaurantId, Dto.DtoDish Dish, Dto.DtoPrice Price, int Quantity, Dto.DtoSearch Search, long Version) : Message, IDomainEvent;
        public record QuantityUpdate(string AggregateId, int Quantity, long Version) : Message, IDomainEvent;
    }
}
