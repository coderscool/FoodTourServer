using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Identity
{
    public static class Command
    {
        public record Register(string UserName, string PassWord, Dto.DtoPerson Person, List<string> Nation, string Role): Message, ICommand;
    }
}
