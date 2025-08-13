using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;

namespace Domain.Aggregates.User
{
    public class AccountUser : AggregateRoot<AccountUserValidator>
    {
        public string Name { get; private set; }
        public string Image { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateAccountUser cmd)
            => RaiseEvent<DomainEvent.AccountUserCreate>((version) => new(cmd.Id, cmd.Name, cmd.Image, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.AccountUserCreate @event)
            => (Id, Name, Image, _) = @event;

    }
}
