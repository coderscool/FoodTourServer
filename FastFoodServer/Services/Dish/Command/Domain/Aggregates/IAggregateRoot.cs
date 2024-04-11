using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public interface IAggregateRoot
    {
        IEnumerable<IDomainEvent> UncommittedEvents { get; }
        void LoadFromHistory(IEnumerable<IDomainEvent> events);
        void Handle(ICommand command);
    }
}
