using Contracts.Abstractions.Messages;
using Contracts.Services.Identity;
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
    public class User : AggregateRoot
    {
        [JsonProperty]
        private readonly List<UserItem> _items = new();

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.Register cmd)
            => RaiseEvent<DomainEvent.RegisterEvent>((version) => new(
                 ObjectId.GenerateNewId().ToString(), cmd.UserName, cmd.PassWord, cmd.Person, cmd.Role, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.RegisterEvent @event)
            => _items.Add(new(@event.AggregateId, @event.UserName, @event.PassWord, @event.Person, @event.Role));
    }
}
