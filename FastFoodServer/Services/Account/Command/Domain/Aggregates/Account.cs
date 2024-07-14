using Contracts.Abstractions.Messages;
using Contracts.Services.Account;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Account : AggregateRoot
    {

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.RequestPayment cmd)
            => RaiseEvent<DomainEvent.PaymentRequest>((version, AggregateId) => new(
                cmd.Id, cmd.RestaurantId, cmd.CustomerId, cmd.DishId, cmd.Customer, cmd.Name, cmd.Price, cmd.Amount, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
