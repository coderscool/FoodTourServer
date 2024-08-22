using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using Contracts.Services.Dish;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Dish : AggregateRoot
    {
        [JsonProperty]
        private readonly List<DishItem> _items = new();

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateDish cmd)
            => RaiseEvent<DomainEvent.DishCreate>((version, AggregateId) => new(
                AggregateId, cmd.PersonId, cmd.Name, cmd.Image, cmd.Price, cmd.Quantity, cmd.Rate, cmd.Search, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.DishCreate @event)
            => _items.Add(new (@event.AggregateId, @event.PersonId, @event.Name, @event.Price, @event.Quantity, @event.Rate, @event.Search));
    }
}
