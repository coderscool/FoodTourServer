using Domain.Abstractions.Aggregates;

namespace Application.Abstractions.Gateways
{
    public interface IEventStoreGateway
    {
        Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken);
        Task<TAggregate> LoadAggregateAsync<TAggregate>(string aggregateId, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new();
    }
}
