using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Gateways
{
    public interface IEventBusGateway
    {
        Task PublishAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken);
        Task PublishAsync(IDomainEvent @event, CancellationToken cancellationToken);
    }
}
