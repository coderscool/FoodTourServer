using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Dish;
using Domain.Abstractions.Aggregates;
using MongoDB.Bson;

namespace Domain.Aggregates
{
    public class Dish : AggregateRoot<DishValidator>
    {
        public string RestaurantId { get; private set; }
        public Dto.DtoDish DishItem { get; private set; }
        public Dto.DtoPrice Price { get; private set; }
        public List<Dto.ExtraFood> Extra { get; private set; } = new();
        public Dto.DtoSearch Search { get; private set; }
        public ushort Quantity { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateDish cmd)
            => RaiseEvent<DomainEvent.DishCreate>((version) => new(ObjectId.GenerateNewId().ToString(), cmd.RestaurantId,
                cmd.Dish, cmd.Extra, cmd.Price, 0, cmd.Search, version));

        public void Handle(Command.UpdateDish cmd)
            => RaiseEvent<DomainEvent.DishUpdate>((version) => new(cmd.Id, cmd.Dish, cmd.Extra, cmd.Price, version));

        public void Handle(Command.UpdateQuantityDish cmd)
            => RaiseEvent<DomainEvent.DishQuantityUpdate>((version) => new(cmd.Id, (ushort)(Quantity + cmd.Quantity), version));

        public void Handle(Command.HiddenDish cmd)
            => RaiseEvent<DomainEvent.DishHidden>((version) => new(cmd.Id, cmd.Hidden, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.DishCreate @event)
            => (Id, RestaurantId, DishItem, Extra, Price, Quantity, Search, _) = @event;

        public void When(DomainEvent.DishUpdate @event)
            => (Id, DishItem, Extra, Price, _) = @event;

        public void When(DomainEvent.DishQuantityUpdate @event)
            => (Id, Quantity, _) = @event;

        public void When(DomainEvent.DishHidden @event)
            => IsDeleted = @event.Hidden;

    }
}
