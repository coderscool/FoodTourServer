using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Identity;
using Domain.Abstractions.Aggregates;
using MongoDB.Bson;

namespace Domain.Aggregates
{
    public class User : AggregateRoot<UserValidator>
    {
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public Dto.DtoPerson Person { get; private set; }
        public string Role { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.Register cmd)
            => RaiseEvent<DomainEvent.RegisterEvent>((version) => new(
                 ObjectId.GenerateNewId().ToString(), cmd.UserName, cmd.PassWord, cmd.Person, cmd.Nation, cmd.Role, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.RegisterEvent @event)
            => (Id, UserName, PassWord, Person, _, Role, _) = @event;
    }
}
