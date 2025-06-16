using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.ShoppingCart;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Domain.Enumerations;
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
        public CartStatus CartStatus { get; private set; } = CartStatus.Empty;
        public PaymentMethod PaymentMethod { get; private set; } = PaymentMethod.PayDirect;

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.AddCartItem cmd)
            => RaiseEvent(version => _items.SingleOrDefault(cartItem => cartItem.DishId == cmd.DishId) is { IsDeleted: false } item
                ? new DomainEvent.CartItemChangedQuantity(cmd.CartId, item.Id, (ushort)(item.Quantity + cmd.Quantity),
                    ChangedTotal(item.CheckOut, cmd.Quantity, item.Price), version)
                : new DomainEvent.CartItemAdd(cmd.CartId, ObjectId.GenerateNewId().ToString(),
                    cmd.RestaurantId, cmd.DishId, cmd.Restaurant, cmd.Dish, cmd.Price, cmd.Quantity, cmd.Note, 
                    CartStatus.Active, false, false, version));

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

            RaiseEvent<DomainEvent.CartItemChangedQuantity>(version => new(Id, item.Id, cmd.Quantity, 
                ChangedTotal(item.CheckOut, cmd.Quantity, item.Price), version));
        }

        public void Handle(Command.ChooseItemCart cmd)
        {
            if (_items.SingleOrDefault(cartItem => cartItem.Id == cmd.Id) is not { IsDeleted: false } item) return;

            RaiseEvent<DomainEvent.CartItemChoose>(version => new(Id, item.Id, cmd.Choose,
                ChangedTotal(cmd.Choose, item.Quantity, item.Price), version));
        }

        public void Handle(Command.CreateCart cmd)
            => RaiseEvent<DomainEvent.CartCreate>((Version) => new(ObjectId.GenerateNewId().ToString(), cmd.CustomerId, 
                cmd.Customer, 0, cmd.Description, CartStatus, Version));

        public void Handle(Command.RemoveCart cmd)
            => RaiseEvent<DomainEvent.CartRemove>(version => new(cmd.CartId, version));

        public void Handle(Command.ChangeDescriptionCart cmd)
            => RaiseEvent<DomainEvent.CartChangeDescription>(version => new(cmd.Id, cmd.Description, version));

        public void Handle(Command.ChangeCustomerCart cmd)
            => RaiseEvent<DomainEvent.CartChangeCustomer>(version => new(cmd.Id, cmd.Customer, version));

        public void Handle(Command.ChangedPaymentCart cmd)
            => RaiseEvent<DomainEvent.CartChangedPayment>(version => new(cmd.CartId, cmd.Payment, version));

        public void Handle(Command.CheckOutCart cmd)
        {
            bool item = _items.Where(x => x.Choose).Any(x => !x.CheckOut);
            RaiseEvent<DomainEvent.CartCheckedOut>(version => new(cmd.CartId, item, version));
        }

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.CartItemAdd @event)
        {
            _items.Add(new(@event.ItemId, @event.RestaurantId, @event.DishId, @event.Restaurant, @event.Dish, @event.Price, @event.Quantity, @event.Note, @event.Choose, @event.CheckOut));
            if(CartStatus == CartStatus.Empty)
            {
                CartStatus = @event.Status;
            }
        }

        public void When(DomainEvent.CartItemChoose @event)
        {
            _items.Single(cartItem => cartItem.Id == @event.Id).SetChoose(@event.Choose);
            Total = @event.Total;
        }

        public void When(DomainEvent.CartItemRemove @event)
            => _items.Single(item => item.Id == @event.Id).Delete();

        public void When(DomainEvent.CartCreate @event)
            => (Id, CustomerId, Customer, Total, Description, _, _) = @event;

        public void When(DomainEvent.CartRemove @event)
            => IsDeleted = true;

        public void When(DomainEvent.CartChangeDescription @event)
            => (Id, Description, _) = @event;

        public void When(DomainEvent.CartChangeCustomer @event)
            => (Id, Customer, _) = @event;

        public void When(DomainEvent.CartItemChangedQuantity @event)
        {
            _items.Single(cartItem => cartItem.Id == @event.Id).SetQuantity(@event.Quantity);
            Total = @event.Total;
        } 

        public void When(DomainEvent.CartCheckedOut @event)
        {
            if(@event.IsSuccess == true)
            {
                foreach (var item in _items.Where(x => x.Choose))
                {
                    item.SetCheckOut(true);
                }
            }
        }
        private ulong ChangedTotal(bool Choice, ushort Quantity, Dto.DtoPrice Price)
            => Choice == true ? Total += Quantity * Price.Cost : Total;

        public static implicit operator Dto.DtoShoppingCart(ShoppingCart cart)
            => new(cart.Id, cart.CustomerId, cart.Customer, cart.Total, cart.PaymentMethod, cart.Description, 
                cart.Items.Select(item => (Dto.CartItem)item).Where(item => item.Choose == true));
    }
}
