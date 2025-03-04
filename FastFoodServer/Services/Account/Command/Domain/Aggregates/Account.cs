using Contracts.Abstractions.Messages;
using Contracts.Services.Account;
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
    public class Account : AggregateRoot
    {
        [JsonProperty]
        private readonly List<AccountItem> _items = new();

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateAccount cmd)
            => RaiseEvent<DomainEvent.AccountCreate>((version) => new(cmd.Id, cmd.Person, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.AccountCreate @event)
            => _items.Add(new(@event.UserId, @event.Person));

    }
}
