using Contracts.DataTransferObject;
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
        public record CartItemAdd(string ItemId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, ushort Time, string Note, long Version) : Message, IDomainEvent;
        public record CartItemRemove(string AggregateId, long Version): Message, IDomainEvent;
        public record CartIncreaseQuantity(string AggregateId, int Quantity, long Version) : Message, IDomainEvent;
        public record CartCheckedOut(string CartId, long Version) : Message, IDomainEvent;
        public record CartCreate(string AggregateId, string CustomerId, Dto.DtoPerson Person, float Total, string Description, long Version) : Message, IDomainEvent;
    }
}
