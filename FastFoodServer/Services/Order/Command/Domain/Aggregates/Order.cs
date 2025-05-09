using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Order;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using MassTransit;
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
        public Dto.DtoPerson Customer { get; private set; }
        public string Status { get; private set; }
        public ulong Total { get; private set; }
        public string Description { get; private set; }


        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.ConfirmOrder cmd)
            => RaiseEvent<DomainEvent.OrderConfirm>((version) => new(Id, Status, version));

        public void Handle(Command.PlaceOrder cmd)
            => RaiseEvent<DomainEvent.OrderPlaced>((version) => new(
                ObjectId.GenerateNewId().ToString(),
                cmd.CustomerId,
                cmd.Customer,
                cmd.Total,
                cmd.Description,
                cmd.Items.Select(cartItem => (Dto.OrderItem)cartItem),
                cmd.Status, version));

        public void Handle(Command.UpdateStatus cmd)
            => RaiseEvent<DomainEvent.StatusUpdate>((version) => new(cmd.Id, cmd.Status, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.OrderConfirm @event)
        {
        }


        public void When(DomainEvent.StatusUpdate @event)
            => _items.Single(x => x.Id == @event.Id).UpdateStatus(@event.Status);

        public void When(DomainEvent.OrderPlaced @event)
        {
            (Id, CustomerId, Customer, Total, _,  var items, Status, _) = @event;
            _items.AddRange(items.Select(item => (OrderItem)item));
        }

        public static implicit operator Dto.DtoOrder(Order order)
            => new(order.Id, order.CustomerId, order.Customer, order.Total, order.Description, order.Status, order.Items.Select(item => (Dto.OrderItem)item));
    }
}
