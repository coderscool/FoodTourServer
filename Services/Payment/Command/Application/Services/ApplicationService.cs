using Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicationService : IApplicationService
    {
        public Task AppendEventsAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TAggregate> LoadAggregateAsync<TAggregate>(string id, CancellationToken cancellationToken) where TAggregate : IAggregateRoot, new()
        {
            throw new NotImplementedException();
        }

        public Task PublishEventAsync(IAggregateRoot aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
