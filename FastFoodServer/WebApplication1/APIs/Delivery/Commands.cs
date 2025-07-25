using Contracts.Services.Delivery;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Delivery.Validators;

namespace WebApplication1.APIs.Delivery
{
    public class Commands
    {
        public record AddShipperDelivery(IBus Bus, string DeliveryId, Payloads.ShipperDeliveryPayload Payload, CancellationToken CancellationToken)
            : Validatable<AddShipperDeliveryValidator>, ICommand<Command.AddShipperDelivery>
        {
            public Command.AddShipperDelivery Command => new(Payload.Id, DeliveryId, Payload.Shipper);
        }

        public record RequireDishDelivery(IBus Bus, string ItemId, CancellationToken CancellationToken)
            : Validatable<RequireDishDeliveryValidator>, ICommand<Command.RequireDishDelivery>
        {
            public Command.RequireDishDelivery Command => new(ItemId);
        }
    }
}
