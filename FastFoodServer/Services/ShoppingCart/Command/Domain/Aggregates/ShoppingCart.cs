using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.ShoppingCart;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using MongoDB.Bson;
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

        public IEnumerable<CartItem> Items
        => _items.AsReadOnly();

        public string Id { get; private set; }
        public string CustomerId { get; private set; }
        public Dto.DtoPerson Customer { get; private set; }
        public float Total { get; private set; }
        public string Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddCartItem cmd)
            => RaiseEvent<DomainEvent.CartItemAdd>((version) => new(ObjectId.GenerateNewId().ToString(), cmd.RestaurantId, cmd.DishId, cmd.Restaurant, 
                cmd.Dish, cmd.Price, cmd.Quantity, cmd.Time, cmd.Note, version));

        public void Handle(Command.CheckAndRemoveDishCart cmd)
        {
            var item = _items
                .Where(cartItem => cartItem.Id == cmd.Id)
                .FirstOrDefault();
            if(item != null)
            {
                RaiseEvent<DomainEvent.CartItemRemove>((Version) => new(cmd.Id, Version));
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        public void Handle(Command.IncreaseQuantityCart cmd)
            => RaiseEvent<DomainEvent.CartIncreaseQuantity>((Version) => new(cmd.Id, cmd.Quantity, Version));

        public void Handle(Command.CreateCart cmd)
            => RaiseEvent<DomainEvent.CartCreate>((Version) => new(ObjectId.GenerateNewId().ToString(), cmd.CustomerId, cmd.Customer, 0, cmd.Description, Version));
        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.CartItemAdd @event)
            => _items.Add(new(@event.ItemId, @event.RestaurantId, @event.DishId, @event.Restaurant, @event.Dish, @event.Quantity, @event.Price, @event.Time, @event.Note));

        public void When(DomainEvent.CartItemRemove @event)
            => _items.RemoveAll(item => item.Id == @event.AggregateId);

        public void When(DomainEvent.CartCreate @event)
            => (Id, CustomerId, Customer, Total, Description, _) = @event;

        private void When(DomainEvent.CartIncreaseQuantity @event)
            => _items.Single(item => item.ItemId == @event.AggregateId).Increase(@event.Quantity);

        public static implicit operator Dto.DtoShoppingCart(ShoppingCart cart)
            => new(cart.Id, cart.CustomerId, cart.Customer, cart.Total, cart.Items.Select(item => (Dto.CartItem)item));
    }
}
