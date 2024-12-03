using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using Contracts.Services.Dish;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
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
            => RaiseEvent<DomainEvent.DishCreate>((version) => new(
                ObjectId.GenerateNewId().ToString(), cmd.PersonId, cmd.Name, cmd.Image, cmd.Price, cmd.Quantity, cmd.Search, version));

        public void Handle(Command.UpdateQuantity cmd)
        {
            var item = _items.Where(x => x.Id == cmd.Id).FirstOrDefault();
            if(item != null)
            {
                RaiseEvent<DomainEvent.QuantityUpdate>((version) => new(
                    cmd.Id, cmd.Quantity, version));
            }
        }
        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.DishCreate @event)
            => _items.Add(new (@event.AggregateId, @event.PersonId, @event.Name, @event.Price, @event.Quantity, @event.Search));
        
        public void When(DomainEvent.QuantityUpdate @event)
            => _items.Single(item => item.Id == @event.AggregateId).UpdateQuantity(@event.Quantity);
    }
}
