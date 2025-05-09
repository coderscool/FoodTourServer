using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Identity
{
    public static class Command
    {
        public record Register(string UserName, string PassWord, Dto.DtoPerson Person, List<string> Nation, string Role): Message, ICommand;
    }
}
