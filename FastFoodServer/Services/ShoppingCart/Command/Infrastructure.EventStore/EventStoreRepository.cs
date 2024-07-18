using Contracts.Abstractions.Messages;
using Domain.Abstractions.EventStore;
using Infrastructure.EventStore.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventStore
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreDbContext _dbContext;

        public EventStoreRepository(EventStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AppendEventAsync(StoreEvent storeEvent, CancellationToken cancellationToken)
        {
            await _dbContext.Set<StoreEvent>().AddAsync(storeEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task AppendSnapshotAsync(Snapshot snapshot, CancellationToken cancellationToken)
        {
            await _dbContext.Set<Snapshot>().AddAsync(snapshot, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Snapshot?> GetSnapshotAsync(string aggregateId, CancellationToken cancellationToken)
            => await _dbContext.Set<Snapshot>()
                .AsNoTracking()
                .Where(snapshot => snapshot.AggregateId.Equals(aggregateId))
                .OrderByDescending(snapshot => snapshot.Version)
                .FirstOrDefaultAsync(cancellationToken);


        public async Task<List<IDomainEvent>> GetStreamAsync(string aggregateId, long? version, CancellationToken cancellationToken)
            => await _dbContext.Set<StoreEvent>()
                .AsNoTracking()
                .Where(@event => @event.AggregateId.Equals(aggregateId))
                .Where(@event => @event.Version > (version ?? 0))
                .Select(@event => @event.Event)
                .ToListAsync(cancellationToken);

    }
}
