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
            => RaiseEvent<DomainEvent.StatisticSellerCreate>((version) => new(cmd.Id, 0, 0, 0, 0, 0, new(0, 0, 0, 0, 0), version));

        public void Handle(Command.UpdateNumberDish cmd)
            => RaiseEvent<DomainEvent.NumberDishUpdate>((version) => new(cmd.Id, 1, version));

        public void Handle(Command.UpdateRevanue cmd)
            => RaiseEvent<DomainEvent.RevenueUpdate>((version) => new(cmd.Id, cmd.Quantity, cmd.Price, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.StatisticSellerCreate @event)
            => (Id, NumberOrder, NumberMeal, NumberDish, Revanue, NumberRate, EvaluateAvg, _) = @event;
    }
}
