using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Order
{
    public class DomainEvent
    {
        public record OrderAddItem(string AggregateId, string RestaurantId, string CustomerId, string DishId, Dto.DtoPerson Restaurant,
            Dto.DtoPerson Customer, string Name, long Price, int Quantity, int Time, bool Status, bool Active, DateTime Date, long Version) : Message, IDomainEvent;
        
        public record OrderConfirm(string OrderId, string Status, long Version) : Message, IDomainEvent;

        public record StatusUpdate(string Id, string Status, long Version) : Message, IDomainEvent;

        public record OrderPlaced(string Id, string CustomerId, Dto.DtoPerson Customer, ulong Total, string Description, IEnumerable<Dto.OrderItem> Items, string Status, long Version) : Message, IDomainEvent;
    }
}
