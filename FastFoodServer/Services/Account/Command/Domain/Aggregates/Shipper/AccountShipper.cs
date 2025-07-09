using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;

namespace Domain.Aggregates.Shipper
{
    public class AccountShipper : AggregateRoot<AccountShipperValidator>
    {
        public Dto.DtoPerson Shipper { get; private set; }
        public string Image { get; private set; }
        public bool IsTransport { get; private set; }
        public bool Status { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateAccountShipper cmd)
            => RaiseEvent<DomainEvent.AccountShipperCreate>((version) => new(cmd.Id, cmd.Shipper, cmd.Image, false, false, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.AccountShipperCreate @event)
            => (Id, Shipper, Image, IsTransport, Status, _) = @event;

    }
}
