using Contracts.Abstractions.Messages;
using Domain.Abstractions.Aggregates;

namespace Application.Services
{
    public interface IApplicationService
    {
        Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken);
        Task PublishEventAsync(IDomainEvent @event, CancellationToken cancellationToken);
        Task<TAggregate> LoadAggregateAsync<TAggregate>(string id, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new();
    }
}
