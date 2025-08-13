using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Statistic;
using Domain.Abstractions.Aggregates;

namespace Domain.Aggregates
{
    public class StatisticSeller : AggregateRoot<StatisticSellerValidator>
    {
        public ushort NumberOrder { get; set; }
        public ushort NumberMeal { get; set; }
        public ushort NumberDish { get; set; }
        public ulong Revanue { get; set; }
        public ushort NumberRate { get; set; }
        public Dto.EvaluateAvg EvaluateAvg { get; set; }

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.CreateSellerStatistic cmd)
            => RaiseEvent<DomainEvent.StatisticSellerCreate>((version) => new(cmd.Id, 0, 0, 0, 0, version));

        public void Handle(Command.UpdateNumberDish cmd)
            => RaiseEvent<DomainEvent.NumberDishUpdate>((version) => new(cmd.Id, NumberDish + 1, version));

        public void Handle(Command.UpdateRevanue cmd)
            => RaiseEvent<DomainEvent.RevenueUpdate>((version) => new(Id, Revanue + cmd.Revanue, version));

        public void Handle(Command.UpdateNumberOrder cmd)
            => RaiseEvent<DomainEvent.NumberOrderUpdate>((version) => new(Id, (ushort)(NumberOrder + cmd.NumberOrder), version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.StatisticSellerCreate @event)
            => (Id, NumberOrder, NumberMeal, NumberDish, Revanue, _) = @event;

        public void When(DomainEvent.NumberDishUpdate @event)
            => NumberDish = (ushort)@event.Quantity;

        public void When(DomainEvent.RevenueUpdate @event)
            => Revanue = @event.Revanue;

        public void When(DomainEvent.NumberOrderUpdate @event)
            => NumberOrder = @event.NumberOrder;

    }
}
