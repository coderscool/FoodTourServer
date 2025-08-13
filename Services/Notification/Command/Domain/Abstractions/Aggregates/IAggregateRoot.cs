using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Aggregates
{
    public interface IAggregateRoot
    {
        IEnumerable<IDomainEvent> UncommittedEvents { get; }
        void Handle(ICommand command);

    }
}
