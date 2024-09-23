using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class DomainEvent
    {
        public record DishCreate(string AggregateId, string PersonId, string Name, string Image, Dto.Price Price, int Quantity, Dto.Rate Rate, Dto.Search Search, long Version) : Message, IDomainEvent;
        public record QuantityUpdate(string AggregateId, int Quantity, long Version) : Message, IDomainEvent;
    }
}
