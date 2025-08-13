using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IApplicationService
    {
        Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken);
        Task<TAggregate> LoadAggregateAsync<TAggregate>(string id, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new();
    }
}
