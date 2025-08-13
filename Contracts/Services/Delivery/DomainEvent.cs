using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Delivery
{
    public class DomainEvent
    {
        public record DeliveryCreate(string Id, string OrderId, string RestaurantId, string CustomerId,
            Dto.DtoPerson Restaurant, Dto.DtoPerson Customer, List<Dto.OrderItem> Items, bool CompletePrepared, string Status, DateTime Date, long Version) : Message, IDomainEvent;

        public record DeliveryAddShipper(string Id, string DeliveryId, Dto.DtoPerson Shipper, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryRequireDish(string ItemId, string OrderId, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryReceiveDish(string ItemId, bool Confirm, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryUpdateOrder(string ItemId, bool Status, long Version) : Message, IDomainEvent;

        public record DeliveryConfirm(string ItemId, bool Confirm, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryRequireComplete(string ItemId, string OrderId, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryComplete(string ItemId, bool Confirm, string Status, long Version) : Message, IDomainEvent;
    }
}
