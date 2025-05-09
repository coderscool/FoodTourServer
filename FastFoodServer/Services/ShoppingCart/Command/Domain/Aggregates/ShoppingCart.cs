using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.ShoppingCart;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace Domain.Aggregates
{
    public class ShoppingCart : AggregateRoot<ShoppingCartValidator>
    {
        [JsonProperty]
        private readonly List<CartItem> _items = new();

        public IEnumerable<CartItem> Items
        => _items.AsReadOnly();

        public string CustomerId { get; private set; }
        public Dto.DtoPerson Customer { get; private set; }
        public ulong Total { get; private set; }
        public string Description { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddCartItem cmd)
            => RaiseEvent(version => _items.SingleOrDefault(cartItem => cartItem.DishId == cmd.DishId) is { IsDeleted: false } item
                ? new DomainEvent.CartItemIncrease(cmd.CartId, item.Id, (ushort)(item.Quantity + cmd.Quantity), IncreasedTotal(cmd.Price, cmd.Quantity), version)
                : new DomainEvent.CartItemAdd(cmd.CartId, ObjectId.GenerateNewId().ToString(),
                    cmd.RestaurantId, cmd.DishId, cmd.Restaurant, cmd.Dish, cmd.Price, cmd.Quantity,
                    IncreasedTotal(cmd.Price, cmd.Quantity), cmd.Note, version));

        public void Handle(Command.CheckAndRemoveDishCart cmd)
        {
            var item = _items
                .Where(cartItem => cartItem.Id == cmd.Id)
                .FirstOrDefault();
            if(item != null)
            {
                RaiseEvent<DomainEvent.CartItemRemove>((Version) => new(cmd.CartId, cmd.Id, Version));
            }
            else
            {
                Console.WriteLine("Faild");
            }
        }

        private void Handle(Command.ChangedQuantityItemCart cmd)
        {
            if (_items.SingleOrDefault(cartItem => cartItem.Id == cmd.ItemId) is not { IsDeleted: false } item) return;

            if (cmd.Quantity > item.Quantity)
                RaiseEvent<DomainEvent.CartItemIncrease>(version
                    => new(Id, item.Id, cmd.Quantity, IncreasedTotal(item.Price, (ushort)(cmd.Quantity - item.Quantity)), version));

            else if (cmd.Quantity < item.Quantity)
                RaiseEvent<DomainEvent.CartItemDecrease>(version
                    => new(Id, item.Id, cmd.Quantity, DecreasedTotal(item.Price, (ushort)(item.Quantity - cmd.Quantity)), version));
        }

        public void Handle(Command.CreateCart cmd)
            => RaiseEvent<DomainEvent.CartCreate>((Version) => new(ObjectId.GenerateNewId().ToString(), cmd.CustomerId, 
                cmd.Customer, 0, cmd.Description, Version));

        public void Handle(Command.RemoveCart cmd)
            => RaiseEvent<DomainEvent.CartRemove>(version => new(cmd.CartId, version));

        public void Handle(Command.ChangeDescriptionCart cmd)
            => RaiseEvent<DomainEvent.CartChangeDescription>(version => new(cmd.Id, cmd.Description, version));

        public void Handle(Command.ChangeCustomerCart cmd)
            => RaiseEvent<DomainEvent.CartChangeCustomer>(version => new(cmd.Id, cmd.Customer, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.CartItemAdd @event)
        {
            _items.Add(new(@event.ItemId, @event.RestaurantId, @event.DishId, @event.Restaurant, @event.Dish, @event.Price, @event.Quantity, @event.Note));
            Total = @event.Total;
        }
        public void When(DomainEvent.CartItemRemove @event)
            => _items.RemoveAll(item => item.Id == @event.Id);

        public void When(DomainEvent.CartCreate @event)
            => (Id, CustomerId, Customer, Total, Description, _) = @event;

        public void When(DomainEvent.CartRemove @event)
            => IsDeleted = true;

        public void When(DomainEvent.CartChangeDescription @event)
            => (Id, Description, _) = @event;

        public void When(DomainEvent.CartChangeCustomer @event)
            => (Id, Customer, _) = @event;

        private ulong IncreasedTotal(Dto.DtoPrice unitPrice, ushort quantity)
            => Total + unitPrice.Cost * quantity;

        private ulong DecreasedTotal(Dto.DtoPrice unitPrice, ushort quantity)
            => Total - unitPrice.Cost * quantity;

        public static implicit operator Dto.DtoShoppingCart(ShoppingCart cart)
            => new(cart.Id, cart.CustomerId, cart.Customer, cart.Total, cart.Description, cart.Items.Select(item => (Dto.CartItem)item));
    }
}
