using Contracts.Abstractions.Messages;
using Contracts.Services.Identity;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class User : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.Register cmd)
            => RaiseEvent<DomainEvent.RegisterEvent>((version, AggregateId) => new(
                AggregateId, cmd.UserName, cmd.PassWord, cmd.Person, cmd.Search, cmd.Image, cmd.Role, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }

    }
}
