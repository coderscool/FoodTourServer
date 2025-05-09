using Contracts.DataTransferObject;
using Contracts.Services.Account;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Account.Validators;

namespace WebApplication1.APIs.Account
{
    public class Commands
    {
        public record ChangedAccount(IBus Bus, string Id, Dto.DtoPerson Person, CancellationToken CancellationToken)
            : Validatable<ChangedAccountValidator>, ICommand<Command.ChangedAccount>
        {
            public Command.ChangedAccount Command => new(Id, Person);
        }
    }
}
