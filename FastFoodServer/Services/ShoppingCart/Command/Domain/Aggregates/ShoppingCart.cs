using Contracts.Abstractions.Messages;
using Contracts.Services.ShoppingCart;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class ShoppingCart : AggregateRoot
    {
        public bool IsActive { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddCartItem cmd)
            => RaiseEvent<DomainEvent.CartItemAdd>((version, AggregateId) => new(
                AggregateId, cmd.RestaurantId, cmd.CustomerId, cmd.DishId, cmd.Amount, version));

        protected override void Apply(IDomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
