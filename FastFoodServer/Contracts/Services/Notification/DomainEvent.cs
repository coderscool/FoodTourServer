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
        public record MessageNotification(string AggregateId, string PersonId, string Message, string JobId, int Time, long Version) : Message, IDomainEvent
        {
            public static MessageNotification Create(string AggregateId, string PersonId, string Message, string JobId, int Time, long Version)
                => new (AggregateId, PersonId, Message, JobId, Time, Version);
        }
    }
}
