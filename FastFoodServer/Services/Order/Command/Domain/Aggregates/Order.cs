using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Order;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Domain.Enumerations;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain.Aggregates
{
    public class Order : AggregateRoot<OrderValidator>
    {
        [JsonProperty]
        private readonly List<OrderItem> _items = new();

        public IEnumerable<OrderItem> Items
            => _items.AsReadOnly();

        public string CustomerId { get; private set; }
        public string ItemId { get; private set; } = string.Empty;
        public Dto.DtoPerson Customer { get; private set; }
        public OrderStatus OrderStatus { get; private set; } = OrderStatus.Pendding;
        public ulong Total { get; private set; }
        public string PaymentMethod { get; private set; }


        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.PlaceOrder cmd)
            => RaiseEvent<DomainEvent.OrderPlaced>((version) => new(
                ObjectId.GenerateNewId().ToString(),
                cmd.CustomerId,
                cmd.Customer,
                cmd.Total,
                cmd.PaymentMethod,
                cmd.Items.Select(cartItem => (Dto.OrderItem)cartItem),
                OrderStatus,
                DateTime.UtcNow,
                version));

        public void Handle(Command.ConfirmOrder cmd)
        {
            if (cmd.Confirm)
            {
                RaiseEvent<DomainEvent.OrderConfirm>((version) => new(cmd.OrderId, cmd.ItemId, cmd.Confirm, OrderItemStatus.Accept, version));
            }
            else
            {
                RaiseEvent<DomainEvent.OrderConfirm>((version) => new(cmd.OrderId, cmd.ItemId, cmd.Confirm, OrderItemStatus.Reject, version));
            }
        }

        public void Handle(Command.RequireOrder cmd)
            => RaiseEvent<DomainEvent.OrderRequire>((version) => new(cmd.OrderId, cmd.ItemId, OrderItemStatus.Require, version));

        public void Handle(Command.ConfirmRequireOrder cmd)
        {
            if (cmd.Confirm)
            {
                RaiseEvent<DomainEvent.OrderConfirmRequire>(version => new(cmd.OrderId, cmd.ItemId, cmd.Confirm, OrderItemStatus.Transport, version));
            }
            else
            {
                RaiseEvent<DomainEvent.OrderConfirmRequire>(version => new(cmd.OrderId, cmd.ItemId, cmd.Confirm, OrderItemStatus.Prepared, version));
            }
        }

        public void Handle(Command.CancelOrder cmd)
            => RaiseEvent<DomainEvent.OrderCancel>((version) => new(cmd.OrderId, cmd.ItemId, OrderStatus.Cancel, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.OrderConfirm @event)
        {
            _items.Single(x => x.Id == @event.ItemId).UpdateStatus(@event.Status);
            ItemId = @event.ItemId;
        }

        public void When(DomainEvent.OrderCancel @event)
            => _items.Single(x => x.Id == @event.ItemId).UpdateStatus(@event.Status);

        public void When(DomainEvent.OrderPlaced @event)
        {
            (Id, CustomerId, Customer, Total, PaymentMethod, var items, OrderStatus, _, _) = @event;
            _items.AddRange(items.Select(item => (OrderItem)item));
        }

        public void When(DomainEvent.OrderCompleteDish @event)
            => _items.Single(x => x.Id == @event.ItemId).UpdateStatus(@event.Status);

        public static implicit operator Dto.DtoOrder(Order order)
           => new(order.Id, order.CustomerId, order.Customer, order.Total, order.Items.Single(x => x.Id == order.ItemId));
    }
}
