﻿using Application.Abstractions.Gateways;
using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventStore
{
    public class EventStoreGateway : IEventStoreGateway
    {
        private const int SnapshotInterval = 5;
        public EventStoreGateway()
        {
        }
        public async Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            foreach (var @event in aggregate.UncommittedEvents)
            {
                Console.WriteLine(@event);
                //if (@event.Version % SnapshotInterval is 0)
                //await _repository.AppendSnapshotAsync(Snapshot.Create(aggregate, _event), cancellationToken);
            }
        }

        public async Task<TAggregate> LoadAggregateAsync<TAggregate>(string aggregateId, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new()
        {
            var aggregate = new TAggregate();
            return (TAggregate)aggregate;
        }
    }
}
