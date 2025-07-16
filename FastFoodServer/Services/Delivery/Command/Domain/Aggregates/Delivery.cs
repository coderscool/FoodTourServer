using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Delivery;
using Domain.Abstractions.Aggregates;
using Domain.Enumerations;

namespace Domain.Aggregates
{
    public class Delivery : AggregateRoot<DeliveryValidator>
    {
        public string OrderId { get; private set; }
        public string CustomerId { get; private set; }
        public string RestaurantId { get; private set; }
        public string ShipperId { get; private set; }
        public Dto.DtoPerson Restaurant { get; private set; }
        public Dto.DtoPerson Customer { get; private set; }
        public Dto.DtoDish Dish { get; private set; }
        public Dto.DtoPerson Shipper { get; private set; }
        public ushort Quantity { get; private set; }
        public Dto.DtoPrice Price { get; private set; }
        public string OrderStatus { get; private set; }
        public string Status { get; private set; } = DeliveryStatus.Pendding;

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.CreateDelivery cmd)
        {
            RaiseEvent<DomainEvent.DeliveryCreate>((version) => new(
                cmd.ItemId,
                cmd.OrderId,
                cmd.RestaurantId,
                cmd.CustomerId,
                cmd.Restaurant,
                cmd.Customer,
                cmd.Dish,
                cmd.Quantity,
                cmd.Price,
                cmd.OrderStatus,
                Status,
                DateTime.UtcNow,
                version));
        }

        public void Handle(Command.AddShipperDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryAddShipper>((version) => new(cmd.Id, cmd.DeliveryId, cmd.Shipper,
                 DeliveryStatus.Accepted, version));

        public void Handle(Command.UpdateOrderDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryUpdateOrder>((version) => new(cmd.ItemId, "Complete", version));

        public void Handle(Command.RequireDishDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryRequireDish>((version) => new(cmd.ItemId, OrderId, DeliveryStatus.Require, version));

        public void Handle(Command.ReceiveDishDelivery cmd)
        {
            if (cmd.Confirm)
            {
                RaiseEvent<DomainEvent.DeliveryReceiveDish>((version) => new(cmd.ItemId, OrderId, cmd.Confirm, DeliveryStatus.Transport, version));
            }
            else
            {
                RaiseEvent<DomainEvent.DeliveryReceiveDish>((version) => new(cmd.ItemId, OrderId, cmd.Confirm, DeliveryStatus.Accepted, version));
            }
        }

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.DeliveryCreate @event)
            => (Id, OrderId, CustomerId, RestaurantId, Restaurant, Customer, Dish, Quantity, Price, OrderStatus, Status, _, _) = @event;

        public void When(DomainEvent.DeliveryAddShipper @event)
            => (_, ShipperId, Shipper, Status, _) = @event;

        public void When(DomainEvent.DeliveryUpdateOrder @event)
            => OrderStatus = @event.Status;

        public void When(DomainEvent.DeliveryReceiveDish @event)
            => OrderStatus = @event.Status;
    }
}
