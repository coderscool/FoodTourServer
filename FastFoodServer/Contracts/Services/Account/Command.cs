using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Account
{
    public static class Command
    {
        public record CreateAccount(string Id, Dto.DtoPerson Person, List<string> Nation) : Message, ICommand;
        public record ChangedAccount(string Id, Dto.DtoPerson Person) : Message, ICommand;
    }
}
