using Application.Abstractions.Gateways;
using Domain.Abstractions.Aggregates;
using Domain.Abstractions.EventStore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventStore
{
    public class EventStoreGateway : IEventStoreGateway
    {
        private readonly int interval = 2;
        private readonly IEventStoreRepository _repository;
        public EventStoreGateway(IEventStoreRepository repository)
        {
            _repository = repository;
        }
        public async Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            foreach (var @event in aggregate.UncommittedEvents.Select(@event => StoreEvent.Create(aggregate, @event)))
            {
                await _repository.AppendEventAsync(@event, cancellationToken);

                if (@event.Version % interval is 0)
                    await _repository.AppendSnapshotAsync(Snapshot.Create(aggregate, @event), cancellationToken);
            }
        }

        public async Task<TAggregate> LoadAggregateAsync<TAggregate>(string aggregateId, CancellationToken cancellationToken)
        where TAggregate : IAggregateRoot, new()
        {
            var snapshot = await _repository.GetSnapshotAsync(aggregateId, cancellationToken);
            var events = await _repository.GetStreamAsync(aggregateId, snapshot?.Version, cancellationToken);

            if (snapshot is null && events is { Count: 0 })
                throw new Exception();

            var aggregate = snapshot?.Aggregate ?? new TAggregate();

            aggregate.LoadFromHistory(events);

            return (TAggregate)aggregate;
        }
    }
}
