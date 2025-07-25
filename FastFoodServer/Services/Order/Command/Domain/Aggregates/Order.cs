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
        private readonly List<OrderGroup> _items = new();

        public IEnumerable<OrderGroup> Items
            => _items.AsReadOnly();

        public string CustomerId { get; private set; }
        public string ItemId { get; private set; } = string.Empty;
        public Dto.DtoPerson Customer { get; private set; }
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
                CreateOrdersFromItems(cmd.Items),
                DateTime.UtcNow,
                version));

        public void Handle(Command.ConfirmOrder cmd)
        {
            if (cmd.Confirm)
            {
                RaiseEvent<DomainEvent.OrderConfirm>((version) => new(cmd.OrderId, cmd.ItemId, cmd.Restaurant, cmd.Confirm, OrderGroupStatus.Accept, version));
            }
            else
            {
                RaiseEvent<DomainEvent.OrderConfirm>((version) => new(cmd.OrderId, cmd.ItemId, cmd.Restaurant, cmd.Confirm, OrderGroupStatus.Reject, version));
            }
        }

        public void Handle(Command.CompleteDishOrder cmd)
            => RaiseEvent<DomainEvent.OrderCompleteDish>((version) => new(cmd.OrderId, cmd.ItemId, OrderGroupStatus.Prepared, version));

        public void Handle(Command.RequireOrder cmd)
            => RaiseEvent<DomainEvent.OrderRequire>((version) => new(cmd.OrderId, cmd.ItemId, OrderGroupStatus.Require, version));

        public void Handle(Command.ConfirmRequireOrder cmd)
        {
            if (cmd.Confirm)
            {
                RaiseEvent<DomainEvent.OrderConfirmRequire>(version => new(cmd.OrderId, cmd.ItemId, cmd.Confirm, OrderGroupStatus.Transport, version));
            }
            else
            {
                RaiseEvent<DomainEvent.OrderConfirmRequire>(version => new(cmd.OrderId, cmd.ItemId, cmd.Confirm, OrderGroupStatus.Prepared, version));
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
            (Id, CustomerId, Customer, Total, PaymentMethod, var items, _, _) = @event;
            _items.AddRange(items.Select(item => (OrderGroup)item));
        }

        public void When(DomainEvent.OrderCompleteDish @event)
            => _items.Single(x => x.Id == @event.ItemId).UpdateStatus(@event.Status);

        public void When(DomainEvent.OrderRequire @event)
            => _items.Single(x => x.Id == @event.ItemId).UpdateStatus(@event.Status);

        public void When(DomainEvent.OrderConfirmRequire @event)
            => _items.Single(x => x.Id == @event.ItemId).UpdateStatus(@event.Status);

        public static implicit operator Dto.DtoOrder(Order order)
           => new(order.Id, order.CustomerId, order.Customer, order.Total, order.Items.Single(x => x.Id == order.ItemId));

        public List<Dto.OrderGroup> CreateOrdersFromItems(IEnumerable<Dto.CartItem> items)
        {
            var groupedByRestaurant = items
                .GroupBy(item => item.RestaurantId);

            var orders = new List<Dto.OrderGroup>();

            foreach (var group in groupedByRestaurant)
            {
                var order = Dto.OrderGroup.FromGroup(group);

                orders.Add(order);
            }

            return orders;
        }
    }
}
