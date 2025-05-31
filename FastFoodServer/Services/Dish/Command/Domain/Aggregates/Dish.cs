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
        public Dto.DtoSearch Search { get; private set; }
        public ushort Quantity { get; private set; }

        public override void Handle(ICommand command)
        => Handle(command as dynamic);

        public void Handle(Command.CreateDish cmd)
            => RaiseEvent<DomainEvent.DishCreate>((version) => new(ObjectId.GenerateNewId().ToString(), cmd.RestaurantId,
                cmd.Dish, cmd.Price, 0, cmd.Search, version));

        public void Handle(Command.UpdatePriceDish cmd)
            => RaiseEvent<DomainEvent.DishUpdatePrice>((version) => new(cmd.Id, cmd.Price, version));

        /*public void Handle(Command.UpdateQuantity cmd)
        {
            var item = _items.Where(x => x.Id == cmd.Id).FirstOrDefault();
            if (item != null)
            {
                RaiseEvent<DomainEvent.QuantityUpdate>((version) => new(
                    cmd.Id, cmd.Quantity, version));
            }
        }*/
        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.DishCreate @event)
            => (Id, RestaurantId, DishItem, Price, Quantity, Search, _) = @event;

        public void When(DomainEvent.DishUpdatePrice @event)
            => (Id, Price, _) = @event;
        //public void When(DomainEvent.QuantityUpdate @event)
            //=> _items.Single(item => item.Id == @event.AggregateId).UpdateQuantity(@event.Quantity);
    }
}
