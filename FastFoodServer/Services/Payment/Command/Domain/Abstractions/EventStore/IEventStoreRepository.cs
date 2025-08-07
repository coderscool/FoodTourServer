using Contracts.Abstractions.Messages;

namespace Domain.Abstractions.EventStore
{
    public interface IEventStoreRepository
    {
        Task AppendEventAsync(StoreEvent storeEvent, CancellationToken cancellationToken);
        Task AppendSnapshotAsync(Snapshot snapshot, CancellationToken cancellationToken);
        Task<List<IDomainEvent>> GetStreamAsync(string aggregateId, long? version, CancellationToken cancellationToken);
        Task<Snapshot?> GetSnapshotAsync(string aggregateId, CancellationToken cancellationToken);
    }
}
