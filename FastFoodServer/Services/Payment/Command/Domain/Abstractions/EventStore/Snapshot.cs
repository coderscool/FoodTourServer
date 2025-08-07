using Domain.Abstractions.Aggregates;

namespace Domain.Abstractions.EventStore
{
    public record Snapshot(string AggregateId, string AggregateType, IAggregateRoot Aggregate, long Version, DateTimeOffset Timestamp)
    {
        public static Snapshot Create(IAggregateRoot aggregate, StoreEvent @event)
            => new(@event.AggregateId, aggregate.GetType().Name, aggregate, @event.Version, @event.Timestamp);
    }
}
