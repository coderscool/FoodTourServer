using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Abstractions.Messages
{
    [ExcludeFromTopology]
    public interface IEvent : IMessage { }

    [ExcludeFromTopology]
    public interface IDelayedEvent : IEvent { }

    [ExcludeFromTopology]
    public interface IVersionedEvent : IEvent
    {
        long Version { get; }
    }

    [ExcludeFromTopology]
    public interface IDomainEvent : IVersionedEvent
    {
    }

    [ExcludeFromTopology]
    public interface ISummaryEvent : IDomainEvent { }
}
