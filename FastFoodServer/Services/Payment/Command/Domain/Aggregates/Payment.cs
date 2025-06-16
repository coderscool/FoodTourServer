using Contracts.Abstractions.Messages;
using Contracts.Services.Payment;
using Domain.Abstractions.Aggregates;
using MongoDB.Bson;

namespace Domain.Aggregates
{
    public class Payment : AggregateRoot<PaymentValidator>
    {
        public ulong Budget { get; private set; }
        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handke(Command.CreatePayment cmd)
            => RaiseEvent<DomainEvent.PaymentCreate>(Version => new(cmd.Id, 0, Version));

        public void Handle(Command.RequestPayment cmd)
            => RaiseEvent<DomainEvent.PaymentRequest>(version => new(
                ObjectId.GenerateNewId().ToString(),
                cmd.OrderId,
                cmd.Price.Cost * cmd.Quantity,
                cmd.PaymentMethod,
                null,
                "pendding",
                false,
                DateTime.UtcNow,
                version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.PaymentCreate @event)
            => (Id, Budget, _) = @event;
    }
}
