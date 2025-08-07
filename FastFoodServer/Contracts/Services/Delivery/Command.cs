using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Delivery
{
    public class Command
    {
        public record CreateDelivery(string OrderId, string ItemId, string RestaurantId, string CustomerId, Dto.DtoPerson Restaurant,
            Dto.DtoPerson Customer, List<Dto.OrderItem> Items, string OrderStatus) : Message, ICommand;

        public record AddShipperDelivery(string Id, string DeliveryId, Dto.DtoPerson Shipper) : Message, ICommand;

        public record UpdateOrderDelivery(string ItemId) : Message, ICommand;

        public record ReceiveDishDelivery(string ItemId, bool Confirm) : Message, ICommand;

        public record RequireDishDelivery(string ItemId) : Message, ICommand;

        public record ConfirmDelivery(string ItemId, bool Confirm) : Message, ICommand;

        public record RequireCompleteDelivery(string ItemId) : Message, ICommand;

        public record CompleteDelivery(string ItemId, bool Confirm) : Message, ICommand;
    }
}
