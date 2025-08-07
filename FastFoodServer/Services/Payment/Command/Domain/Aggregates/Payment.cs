using Contracts.Abstractions.Messages;
using Contracts.Services.Payment;
using Domain.Abstractions.Aggregates;
using MongoDB.Bson;

namespace Domain.Aggregates
{
    public class Payment : AggregateRoot<PaymentValidator>
    {
        public string OrderId { get; set; }
        public ulong Total { get; set; }
        public string PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public string PaymentStatus { get; set; }
        public bool SellerConfirm { get; set; }
        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.RequestPayment cmd)
        {
            ulong total = 0;

            foreach (var item in cmd.Group.OrderItem)
            {
                total += item.Price.Cost * item.Quantity;
            }
            RaiseEvent<DomainEvent.PaymentRequest>(version => new(
                ObjectId.GenerateNewId().ToString(),
                cmd.Group.GroupId,
                total,
                cmd.PaymentMethod,
                null,
                "pendding",
                false,
                DateTime.UtcNow,
                version));
        }

        public void Handle(Command.CompletePayment cmd)
            => RaiseEvent<DomainEvent.PaymentComplete>(version => new(cmd.ItemId, "Complete", version));

        public void Handle(Command.SellerConfirmPayment cmd)
            => RaiseEvent<DomainEvent.PaymentSellerConnfirm>(version => new(cmd.ItemId, true, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.PaymentRequest @event)
            => (Id, OrderId, Total, PaymentMethod, TransactionId, PaymentStatus, SellerConfirm, _, _) = @event;

        public void When(DomainEvent.PaymentComplete @event)
            => (Id, PaymentStatus, _) = @event;

        public void When(DomainEvent.PaymentSellerConnfirm @event)
            => (Id, SellerConfirm, _) = @event;
    }
}
