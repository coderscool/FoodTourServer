using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;

namespace Domain.Aggregates
{
    public class Account : AggregateRoot<AccountValidator>
    {
        public Dto.DtoPerson Person { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateAccount cmd)
            => RaiseEvent<DomainEvent.AccountCreate>((version) => new(cmd.Id, cmd.Person, cmd.Nation, version));

        public void Handlle(Command.ChangedAccount cmd)
            => RaiseEvent<DomainEvent.AccountChanged>((version) => new(Id, cmd.Person, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.AccountCreate @event)
            => (Id, Person, _, _) = @event;

        public void When(DomainEvent.AccountChanged @event)
            => (Id, Person, _) = @event;

    }
}
