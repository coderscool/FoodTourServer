using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class DomainEvent
    {
        public record AccountCreate(string AccountId, Dto.DtoPerson Person, List<string> Nation, long Version) : Message, IDomainEvent;

        public record AccountChanged(string Id, Dto.DtoPerson Person, long Version) : Message, IDomainEvent;

    }
}
