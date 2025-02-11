using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class DomainEvent
    {
        public record RegisterEvent(string AggregateId, string UserName, string PassWord, Dto.DtoPerson Person, string Role, long Version) : Message, IDomainEvent;
    }
}
