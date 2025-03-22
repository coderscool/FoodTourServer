using Contracts.Abstractions.Messages;
using Contracts.Services.Payment;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Payment : AggregateRoot
    {
        public string Id { get; private set; }
        public ulong Amount { get; private set; }
        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.RequestPayment cmd)
        {
            if(Amount >= cmd.Total)
            {
                RaiseEvent<DomainEvent.PaymentRequest>(version => new(cmd.Id, cmd.OrderId, cmd.Total, true, version));
            }
            else
            {
                RaiseEvent<DomainEvent.PaymentRequest>(version => new(cmd.Id, cmd.OrderId, cmd.Total, false, version));
            }
        }

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
