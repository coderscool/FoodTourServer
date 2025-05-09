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
        public record CartItemAdd(string CartId, string ItemId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, ulong Total, string Note, long Version) : Message, IDomainEvent;
        public record CartItemRemove(string Id, string CartId, long Version): Message, IDomainEvent;
        public record CartChangedQuantityItem(string CartId, string Id, ushort Quantity, long Version) : Message, IDomainEvent;
        public record CartItemIncrease(string Id, string CartId, ushort Quantity, ulong Total, long Version) : Message, IDomainEvent;
        public record CartItemDecrease(string Id, string CartId, ushort Quantity, ulong Total, long Version) : Message, IDomainEvent;
        public record CartCheckedOut(string CartId, long Version) : Message, IDomainEvent;
        public record CartRemove(string CartId, long Version) : Message, IDomainEvent;
        public record CartCreate(string CartId, string CustomerId, Dto.DtoPerson Customer, ulong Total, string Description, long Version) : Message, IDomainEvent;
        public record CartChangeDescription(string Id, string Description, long Version) : Message, IDomainEvent;
        public record CartChangeCustomer(string Id, Dto.DtoPerson Customer, long Version) : Message, IDomainEvent;
    }
}
