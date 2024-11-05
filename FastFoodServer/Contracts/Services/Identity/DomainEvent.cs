using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class DomainEvent
    {
        public record RegisterEvent(string AggregateId, string UserName, string PassWord, Dto.Person Person, List<string>  Nation, string Image, string Role, long Version) : Message, IDomainEvent;

    }
}
