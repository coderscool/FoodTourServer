using Contracts.Abstractions.Messages;
using Contracts.Services.ShoppingCart;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class ShoppingCart : AggregateRoot
    {
        [JsonProperty]
        private readonly List<CartItem> _items = new();

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddCartItem cmd)
            => RaiseEvent<DomainEvent.CartItemAdd>((version, AggregateId) => new(AggregateId, cmd.RestaurantId, cmd.CustomerId, cmd.DishId, cmd.Amount, version));

        public void Handle(Command.CheckAndRemoveDishCart cmd)
        {
            var item = _items
                .Where(cartItem => cartItem.Id == cmd.Id)
                .FirstOrDefault();
            if(item != null)
            {
                RaiseEvent<DomainEvent.CartItemRemove>((Version, AggregateId) => new(cmd.Id, Version));
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        public void Handle(Command.IncreaseQuantityCart cmd)
            => RaiseEvent<DomainEvent.CartIncreaseQuantity>((Version, AggregateId) => new(cmd.Id, cmd.Quantity, Version));
        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.CartItemAdd @event)
            => _items.Add(new(@event.AggregateId, @event.RestaurantId, @event.CustomerId, @event.DishId, @event.Amount));

        public void When(DomainEvent.CartItemRemove @event)
            => _items.RemoveAll(item => item.Id == @event.AggregateId);

        private void When(DomainEvent.CartIncreaseQuantity @event)
            => _items.Single(item => item.Id == @event.AggregateId).Increase(@event.Quantity);
    }
}
