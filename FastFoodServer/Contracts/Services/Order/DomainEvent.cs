using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Order
{
    public class DomainEvent
    {
        public record OrderAddItem(string AggregateId, string RestaurantId, string CustomerId, string DishId, Dto.Person Restaurant,
            Dto.Person Customer, string Name, Dto.Price Price, int Amount, int Time, string Status, DateTime Date, long Version) : Message, IDomainEvent;
    }
}
