using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.ShoppingCart
{
    public class DomainEvent
    {
        public record CartItemAdd(string CustomerId, string ItemId, string RestaurantId, string DishId, Dto.DtoDish Dish,
            List<string> Extra, Dto.DtoPrice Price, ushort Quantity, string Note, bool CheckOut, long Version) : Message, IDomainEvent;
        public record CartItemRemove(string Id, string CartId, long Version): Message, IDomainEvent;
        public record CartCreate(string Id, long Version) : Message, IDomainEvent;
        public record CartItemChangedQuantity(string CustomerId, string ItemId, ushort Quantity, long Version) : Message, IDomainEvent;
        public record CartCheckedOut(string CartId, List<string> ChooseId, Dto.DtoPerson Customer, ulong Total, string PaymentMethod, long Version) : Message, IDomainEvent;
    }
}
