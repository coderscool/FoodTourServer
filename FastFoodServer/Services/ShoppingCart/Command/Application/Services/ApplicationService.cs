﻿using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Domain.Abstractions.Aggregates;

namespace Application.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IEventStoreGateway _eventStoreGateway;
        private readonly IEventBusGateway _eventBusGateway;
        public ApplicationService(IEventStoreGateway eventStoreGateway, IEventBusGateway eventBusGateway)
        {
            _eventStoreGateway = eventStoreGateway;
            _eventBusGateway = eventBusGateway;
        }
        public async Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            await _eventStoreGateway.AppendEventsAsync(aggregate, cancellationToken);
            await _eventBusGateway.PublishAsync(aggregate.UncommittedEvents, cancellationToken);
        }

        public async Task<TAggregate> LoadAggregateAsync<TAggregate>(string id, CancellationToken cancellationToken)
            where TAggregate : IAggregateRoot, new()
            => await _eventStoreGateway.LoadAggregateAsync<TAggregate>(id, cancellationToken);

        public Task PublishEventAsync(IDomainEvent @event, CancellationToken cancellationToken)
            => _eventBusGateway.PublishAsync(@event, cancellationToken);


    }
}
