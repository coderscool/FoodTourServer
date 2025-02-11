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
        
        public record OrderConfirm(string AggregateId, string RestaurantId, string CustomerId, string DishId, Dto.DtoPerson Customer,
            string Name, long Price, int Quantity, int Time, DateTime Date, long Version) : Message, IDomainEvent;

        public record StatusUpdate(string AggregateId, bool Status, long Version) : Message, IDomainEvent;
    }
}
