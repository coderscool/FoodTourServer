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
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddItemOrder cmd)
            => RaiseEvent<DomainEvent.OrderAddItem>((version, AggregateId) => new(
                AggregateId, cmd.PersonId, cmd.DishId, cmd.Person, cmd.Dish, cmd.Image, cmd.Price, cmd.Amount, cmd.Time, cmd.Date, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
