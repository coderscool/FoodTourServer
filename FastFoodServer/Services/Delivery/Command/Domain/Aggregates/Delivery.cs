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
        public Dto.DtoPerson Shipper { get; private set; }
        public bool OrderStatus { get; private set; }
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
                cmd.Items,
                false,
                Status,
                DateTime.UtcNow,
                version));
        }

        public void Handle(Command.AddShipperDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryAddShipper>((version) => new(cmd.Id, cmd.DeliveryId, cmd.Shipper,
                 DeliveryStatus.Accepted, version));

        public void Handle(Command.UpdateOrderDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryUpdateOrder>((version) => new(cmd.ItemId, true, version));

        public void Handle(Command.RequireDishDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryRequireDish>((version) => new(cmd.ItemId, OrderId, DeliveryStatus.Require, version));

        public void Handle(Command.ReceiveDishDelivery cmd)
        {
            if (cmd.Confirm)
            {
                RaiseEvent<DomainEvent.DeliveryReceiveDish>((version) => new(cmd.ItemId, cmd.Confirm, DeliveryStatus.Transport, version));
            }
            else
            {
                RaiseEvent<DomainEvent.DeliveryReceiveDish>((version) => new(cmd.ItemId, cmd.Confirm, DeliveryStatus.Accepted, version));
            }
        }

        public void Handle(Command.RequireCompleteDelivery cmd)
            => RaiseEvent<DomainEvent.DeliveryRequireDish>((version) => new(Id, OrderId, DeliveryStatus.RequireComplete, version));

        public void Handle(Command.CompleteDelivery cmd)
        {
            if(cmd.Confirm)
            {
                RaiseEvent<DomainEvent.DeliveryComplete>((version) => new(Id, cmd.Confirm, DeliveryStatus.Complete, version));
            }
            else
            {
                RaiseEvent<DomainEvent.DeliveryComplete>((version) => new(Id, cmd.Confirm, DeliveryStatus.Transport, version));
            }
        }

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.DeliveryCreate @event)
            => (Id, OrderId, CustomerId, RestaurantId, _, _, _, OrderStatus, Status, _, _) = @event;

        public void When(DomainEvent.DeliveryAddShipper @event)
            => (ShipperId, Id, Shipper, Status, _) = @event;

        public void When(DomainEvent.DeliveryUpdateOrder @event)
            => OrderStatus = @event.Status;

        public void When(DomainEvent.DeliveryReceiveDish @event)
            => Status = @event.Status;

        public void When(DomainEvent.DeliveryRequireDish @event)
            => Status = @event.Status;

        public void When(DomainEvent.DeliveryComplete @event)
            => Status = @event.Status;

        public void When(DomainEvent.DeliveryRequireComplete @event)
            => Status = @event.Status;
    }
}
