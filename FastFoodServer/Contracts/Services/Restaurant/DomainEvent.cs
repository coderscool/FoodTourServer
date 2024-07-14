using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class DomainEvent
    {
        public record ExpireOrderRestaurant(string AggregateId, long Version) : Message, IDomainEvent;
    }
}
