using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Notification
{
    public static class DomainEvent
    {
        public record MessageNotification(string AggregateId, string PersonId, string Name, string Message, bool Check, DateTime Date, long Version) : Message, IDomainEvent;
    }
}
