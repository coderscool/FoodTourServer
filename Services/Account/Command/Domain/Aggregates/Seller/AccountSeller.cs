using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;

namespace Domain.Aggregates.Seller
{
    public class AccountSeller : AggregateRoot<AccountSellerValidator>
    {
        public Dto.DtoPerson Seller { get; private set; }
        public string Image { get; private set; }
        public string Nation { get; private set; }
        public Dto.TimeActive TimeActive { get; private set; }
        public bool Status { get; private set; }


        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        private void Handle(Command.CreateAccountSeller cmd)
            => RaiseEvent<DomainEvent.AccountSellerCreate>((version) => new(cmd.Id, cmd.Seller, cmd.Image, cmd.Nation, cmd.TimeActive, false, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        private void When(DomainEvent.AccountSellerCreate @event)
            => (Id, Seller, Image, Nation, TimeActive, Status, _) = @event;

    }
}
