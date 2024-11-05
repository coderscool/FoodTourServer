using Contracts.Abstractions.Messages;
using Contracts.Services.Statistic;
using Domain.Abstractions.Aggregates;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Statistic : AggregateRoot
    {
        [JsonProperty]
        private readonly List<StatisticItem> _items = new();

        public override void Handle(ICommand command)
            => Handle(command as dynamic);

        public void Handle(Command.CreateStatistic cmd)
            => RaiseEvent<DomainEvent.StatisticCreate>((version) => new(cmd.Id, 0, 0, 0, 0, 0, new(0, 0, 0, 0, 0), version));

        public void Handle(Command.UpdateNumberDish cmd)
            => RaiseEvent<DomainEvent.NumberDishUpdate>((version) => new(cmd.Id, 1, version));

        public void Handle(Command.UpdateRevanue cmd)
            => RaiseEvent<DomainEvent.RevenueUpdate>((version) => new(cmd.Id, cmd.Quantity, cmd.Price, version));

        protected override void Apply(IDomainEvent @event)
            => When(@event as dynamic);

        public void When(DomainEvent.StatisticCreate @event)
            => _items.Add(new(@event.AggregateId, @event.NumberOrder, @event.NumberMeal, @event.NumberDish, @event.Revenue, @event.NumberRate, @event.EvaluateAvg));

        public void When(DomainEvent.NumberDishUpdate @event)
            => _items.Single(x => x.Id == @event.AggregateId).UpdateNumberDish(@event.Quantity);

        public void When(DomainEvent.RevenueUpdate @event)
            => _items.Single(x => x.Id == @event.AggregateId).UpdateRevanue(@event.Quantity, @event.Price);
    }
}
