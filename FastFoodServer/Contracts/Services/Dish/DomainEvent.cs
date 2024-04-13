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
        public record DishCreate(Guid AggregateId, Dto.Dish Dish, Dto.Price Price, Dto.Rate Rate, Dto.Search Search, long Version) : Message, IDomainEvent;
    }
}
