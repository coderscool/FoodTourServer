using Contracts.Services.Identity;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Identities.Validators;

namespace WebApplication1.APIs.Identities
{
    public class Commands
    {
        public record RegisterUser(IBus Bus, Payloads.SignUp Payload, CancellationToken CancellationToken)
        : Validatable<RegisterUserValidator>, ICommand<Command.Register>
        {
            public Command.Register Command
                => new(Payload.UserName, Payload.PassWord, Payload.Person, Payload.Role);
        }
    }
}
