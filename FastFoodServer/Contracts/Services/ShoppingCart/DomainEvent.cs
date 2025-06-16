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
        public record CartItemAdd(string CartId, string ItemId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, 
            Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note, string Status, bool Choose, bool CheckOut, long Version) : Message, IDomainEvent;
        public record CartItemRemove(string Id, string CartId, long Version): Message, IDomainEvent;
        public record CartItemChangedQuantity(string CartId, string Id, ushort Quantity, ulong Total, long Version) : Message, IDomainEvent;
        public record CartCheckedOut(string CartId, bool IsSuccess, long Version) : Message, IDomainEvent;
        public record CartRemove(string CartId, long Version) : Message, IDomainEvent;
        public record CartCreate(string CartId, string CustomerId, Dto.DtoPerson Customer, ulong Total, string Status, string Description, long Version) : Message, IDomainEvent;
        public record CartChangeDescription(string Id, string Description, long Version) : Message, IDomainEvent;
        public record CartChangeCustomer(string Id, Dto.DtoPerson Customer, long Version) : Message, IDomainEvent;
        public record CartItemChoose(string CartId, string Id, bool Choose, ulong Total, long Version) : Message, IDomainEvent;
        public record CartChangedPayment(string CartId, string Payment, long Version) : Message, IDomainEvent;
    }
}
