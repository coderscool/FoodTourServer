using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Order
{
    public class DomainEvent
    {
        //public record OrderAddItem(string AggregateId, string RestaurantId, string CustomerId, string DishId, Dto.DtoPerson Restaurant,
          //  Dto.DtoPerson Customer, string Name, long Price, int Quantity, int Time, bool Status, bool Active, DateTime Date, long Version) : Message, IDomainEvent;
        public record OrderConfirm(string OrderId, string ItemId, Dto.DtoPerson Restaurant, bool Confirm, string Status, long Version) : Message, IDomainEvent;
        public record OrderCancel(string OrderId, string ItemId, string Status, long Version) : Message, IDomainEvent;
        public record OrderCompleteDish(string OrderId, string ItemId, string Status, long Version) : Message, IDomainEvent;
        public record OrderPlaced(string Id, string CustomerId, Dto.DtoPerson Customer, ulong Total, string PaymentMethod, List<Dto.OrderGroup> Items, DateTime Date, long Version) : Message, IDomainEvent;
        public record OrderRequire(string OrderId, string ItemId, string Status, long Version) : Message, IDomainEvent;
        public record OrderRequireComplete(string OrderId, string ItemId, string Status, long Version) : Message, IDomainEvent;
        public record OrderComplete(string OrderId, string ItemId, bool Confirm, string Status, long Version) : Message, IDomainEvent;
        public record OrderConfirmRequire(string OrderId, string ItemId, bool Confirm, string Status, long Version) : Message, IDomainEvent;
    }
}
