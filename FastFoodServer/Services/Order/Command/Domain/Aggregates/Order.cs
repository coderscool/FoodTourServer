using Contracts.Abstractions.Messages;
using Contracts.Services.Order;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Order : AggregateRoot
    {

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddItemOrder cmd)
            => RaiseEvent<DomainEvent.OrderAddItem>((version, AggregateId) => new(
                AggregateId, cmd.RestaurantId, cmd.CustomerId, cmd.DishId, cmd.Restaurant, cmd.Customer, cmd.Name, 
                cmd.Price, cmd.Amount, cmd.Time, cmd.Status, cmd.Date, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
