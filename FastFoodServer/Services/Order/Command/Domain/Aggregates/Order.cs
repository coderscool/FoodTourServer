using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Order;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Order : AggregateRoot
    {
        [JsonProperty]
        private readonly List<OrderItem> _items = new();

        public string OrderId { get; private set; }
        public string CustomerId { get; private set; }
        public Dto.DtoPerson Customer { get; private set; }
        public string Status { get; private set; }
        public float Total { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.ConfirmOrder cmd)
        {
            var item = _items
                .Where(orderItem => orderItem.ItemId == cmd.Id)
                .FirstOrDefault();

            if(item != null && item.Active == false)
            {
                RaiseEvent<DomainEvent.OrderConfirmSuccess>((version) => new(OrderId, CustomerId, Customer, _items.Select(item => (Dto.OrderItem)item), DateTime.UtcNow, version));
            }
        }

        public void Handle(Command.PlaceOrder cmd)
            => RaiseEvent<DomainEvent.OrderPlaced>((version) => new(
                ObjectId.GenerateNewId().ToString(),
                cmd.CustomerId,
                cmd.Customer,
                cmd.Total,
                cmd.Items.Select(cartItem => (Dto.OrderItem)cartItem),
                cmd.Status, version));
        public void Handle(Command.UpdateStatus cmd)
            => RaiseEvent<DomainEvent.StatusUpdate>((version) => new(cmd.Id, cmd.Status, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.OrderConfirmSuccess @event)
            => Status = "Success";

        public void When(DomainEvent.StatusUpdate @event)
            => _items.Single(x => x.ItemId == @event.AggregateId).UpdateStatus(@event.Status);
    }
}
