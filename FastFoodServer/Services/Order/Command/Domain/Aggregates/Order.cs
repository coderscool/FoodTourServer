using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using Contracts.Services.Order;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
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

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddItemOrder cmd)
            => RaiseEvent<DomainEvent.OrderAddItem>((version, AggregateId) => new(
                AggregateId, cmd.RestaurantId, cmd.CustomerId, cmd.DishId, cmd.Restaurant, cmd.Customer, cmd.Name, 
                cmd.Price, cmd.Quantity, cmd.Time, false, false, cmd.Date, version));

        public void Handle(Command.ConfirmOrder cmd)
        {
            var item = _items
                .Where(orderItem => orderItem.Id == cmd.Id)
                .FirstOrDefault();

            if(item != null && item.Active == false)
            {
                RaiseEvent<DomainEvent.OrderConfirm>((version, AggregateId) => new(
                    cmd.Id, item.RestaurantId, item.CustomerId, item.DishId, new Dto.Person(item.Customer.Name, item.Customer.Address, item.Customer.Phone),
                    item.Name, item.Price, item.Quantity, item.Time, item.Date, version));
            }
        }

        public void Handle(Command.UpdateStatus cmd)
            => RaiseEvent<DomainEvent.StatusUpdate>((version, AggregateId) => new(cmd.Id, cmd.Status, version));
        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.OrderConfirm @event)
        {

        }

        public void When(DomainEvent.StatusUpdate @event)
            => _items.Single(x => x.Id == @event.AggregateId).UpdateStatus(@event.Status);

        public void When(DomainEvent.OrderAddItem @event)
            => _items.Add(new(@event.AggregateId, @event.RestaurantId, @event.CustomerId, @event.DishId, @event.Restaurant,
                @event.Customer, @event.Name, @event.Price, @event.Quantity, @event.Time, false, false, @event.Date));
    }
}
