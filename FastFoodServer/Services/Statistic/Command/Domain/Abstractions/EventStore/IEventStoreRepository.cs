using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
