using Contracts.Abstractions.Messages;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.EventStore
{
    public record StoreEvent(string AggregateId, string AggregateType, string EventType, IDomainEvent Event, long Version, DateTimeOffset Timestamp)
    {
        public static StoreEvent Create(IAggregateRoot aggregate, IDomainEvent @event)
            => new(aggregate.Id, aggregate.GetType().Name, @event.GetType().Name, @event, @event.Version, @event.Timestamp);
    }
}
