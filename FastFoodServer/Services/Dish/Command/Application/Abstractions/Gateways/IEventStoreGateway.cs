using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Gateways
{
    public interface IEventStoreGateway
    {
        Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken);
        Task<TAggregate> LoadAggregateAsync<TAggregate>(string aggregateId, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new();
    }
}
