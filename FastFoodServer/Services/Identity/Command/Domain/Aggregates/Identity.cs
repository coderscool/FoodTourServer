using Contracts.Abstractions.Messages;
using Contracts.Services.Identity;
using Domain.Abstractions.Aggregates;
using MongoDB.Bson;

namespace Domain.Aggregates
{
    public class Identity : AggregateRoot<IdentityValidator>
    {
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Role { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.RegisterUser cmd)
            => RaiseEvent<DomainEvent.UserRegister>((version) => new(
                 ObjectId.GenerateNewId().ToString(), cmd.UserName, cmd.PassWord, cmd.Name, cmd.Image, cmd.Role, version));

        public void Handle(Command.RegisterSeller cmd)
            => RaiseEvent<DomainEvent.SellerRegister>((version) => new(
                 ObjectId.GenerateNewId().ToString(), cmd.UserName, cmd.PassWord, cmd.Seller, cmd.Image, cmd.Nation, cmd.TimeActive, cmd.Role, version));

        public void Handle(Command.RegisterShipper cmd)
            => RaiseEvent<DomainEvent.ShipperRegister>((version) => new(
                 ObjectId.GenerateNewId().ToString(), cmd.UserName, cmd.PassWord, cmd.Shipper, cmd.Image, cmd.Role, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.UserRegister @event)
            => (Id, UserName, PassWord, _, _, Role, _) = @event;

        public void When(DomainEvent.SellerRegister @event)
            => (Id, UserName, PassWord, _, _, _, _, Role, _) = @event;

        public void When(DomainEvent.ShipperRegister @event)
            => (Id, UserName, PassWord, _, _, Role, _) = @event;
    }
}
