using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Payment
{
    public static class DomainEvent
    {
        public record PaymentRequest(string Id, string OrderId, ulong Total, bool Status, long Version) : Message, IDomainEvent;
    }
}
