using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.EventStore
{
    public record Snapshot(string AggregateId, string AggregateType, IAggregateRoot Aggregate, long Version, DateTimeOffset Timestamp)
    {
        public static Snapshot Create(IAggregateRoot aggregate, StoreEvent @event)
            => new(aggregate.Id, aggregate.GetType().Name, aggregate, @event.Version, @event.Timestamp);
    }
}
