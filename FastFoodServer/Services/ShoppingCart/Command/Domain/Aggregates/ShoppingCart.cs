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

        public List<string> Chooses { get; set; } = new();

        public IEnumerable<CartItem> Items
        => _items.AsReadOnly();

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateCart cmd)
            => RaiseEvent<DomainEvent.CartCreate>(version => new(cmd.Id, version));

        public void Handle(Command.AddCartItem cmd)
            => RaiseEvent(version => _items.SingleOrDefault(cartItem => cartItem.DishId == cmd.DishId) is { IsDeleted: false } item
                ? new DomainEvent.CartItemChangedQuantity(cmd.CustomerId, item.Id, (ushort)(item.Quantity + cmd.Quantity), version)
                : new DomainEvent.CartItemAdd(cmd.CustomerId, ObjectId.GenerateNewId().ToString(),
                    cmd.RestaurantId, cmd.DishId, cmd.Dish, cmd.Extra, cmd.Price, cmd.Quantity, cmd.Note, false, version));

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

            RaiseEvent<DomainEvent.CartItemChangedQuantity>(version => new(cmd.CustomerId, item.Id, cmd.Quantity, version));
        }


        public void Handle(Command.CheckOutCart cmd)
        {
            //bool item = _items.Where(x => Chooses.Contains(x.Id)).Any(x => !x.CheckOut);
            //if(item == true)
            //{
                RaiseEvent<DomainEvent.CartCheckedOut>(version => new(cmd.CartId, cmd.ChooseId, cmd.Customer, cmd.Total, cmd.PaymentMethod, version));
            //}
        }

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);


        public void When(DomainEvent.CartCreate @event)
            => Id = @event.Id;
        public void When(DomainEvent.CartItemAdd @event)
        {
            _items.Add(new(@event.ItemId, @event.RestaurantId, @event.DishId, @event.Dish, @event.Extra, @event.Price, @event.Quantity, @event.Note, @event.CheckOut));
            Id = @event.CustomerId;
        }

        public void When(DomainEvent.CartItemChangedQuantity @event)
        {
            _items.Single(cartItem => cartItem.Id == @event.ItemId).SetQuantity(@event.Quantity);
        }


        public void When(DomainEvent.CartItemRemove @event)
            => _items.Single(item => item.Id == @event.Id).Delete();

        public void When(DomainEvent.CartCheckedOut @event)
            => Chooses = @event.ChooseId;

        public static implicit operator Dto.DtoShoppingCart(ShoppingCart cart)
            => new(cart.Id, cart.Items.Select(item => (Dto.CartItem)item).Where(item => cart.Chooses.Contains(item.ItemId)));
    }
}
