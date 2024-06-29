using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.ShoppingCart
{
    public class DomainEvent
    {
        public record CartItemAdd(string AggregateId, string RestaurantId, string CustomerId, string DishId, int Amount, long Version) : Message, IDomainEvent;
    }
}
