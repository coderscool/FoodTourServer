﻿using Contracts.Abstractions.Messages;
using Contracts.Services.Restaurant;
using Domain.Abstractions.Aggregates;
using Domain.Entities.Res;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Restaurant : AggregateRoot
    {
        [JsonProperty]
        private readonly List<RestaurantItem> _items = new();

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.CreateBillRestaurant cmd)
            => RaiseEvent<DomainEvent.RestaurantCreateBill>((version, AggregateId) => new(cmd.Id, cmd.RestaurantId,
                cmd.CustomerId, cmd.DishId, cmd.Customer, cmd.Name, cmd.Price, cmd.Quantity, cmd.Time, false, false, cmd.Date, version));

        public void Handle(Command.ReplyRestaurant cmd)
        {
            var item = _items
                .Where(resItem => resItem.Id == cmd.Id)
                .FirstOrDefault();

            if (item != null)
            {
                RaiseEvent<DomainEvent.RestaurantReply>((version, AggregateId) => new(item.Id, item.RestaurantId, item.DishId,
                    item.CustomerId, item.Price, item.Quantity, cmd.Status, version));
            }
        }

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.RestaurantCreateBill @event)
            => _items.Add(new(@event.AggregateId, @event.RestaurantId, @event.CustomerId, @event.DishId, @event.Customer,
                @event.Name, @event.Price, @event.Quantity, @event.Time, false, false, @event.Date));

        public void When(DomainEvent.RestaurantReply @event)
            => _items.Single(item => item.Id == @event.AggregateId).UpdateStatus(@event.Status);
    }
}
