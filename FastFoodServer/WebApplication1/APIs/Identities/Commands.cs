using Contracts.Services.Identity;
using MassTransit;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Identities.Validators;

namespace WebApplication1.APIs.Identities
{
    public class Commands
    {
        public record RegisterUser(IBus Bus, Payloads.SignUpUser Payload, CancellationToken CancellationToken)
            : Validatable<RegisterUserValidator>, ICommand<Command.RegisterUser>
        {
            public Command.RegisterUser Command
                => new(Payload.UserName, Payload.PassWord, Payload.Name, Payload.Image, Payload.Role);
        }

        public record RegisterSeller(IBus Bus, Payloads.SignUpSeller Payload, CancellationToken CancellationToken)
            : Validatable<RegisterSellerValidator>, ICommand<Command.RegisterSeller>
        {
            public Command.RegisterSeller Command
                => new(Payload.UserName, Payload.PassWord, Payload.Seller, Payload.Image, Payload.Nation, Payload.TimeActive, Payload.Role);
        }

        public record RegisterShipper(IBus Bus, Payloads.SignUpShipper Payload, CancellationToken CancellationToken)
            : Validatable<RegisterShipperValidator>, ICommand<Command.RegisterShipper>
        {
            public Command.RegisterShipper Command
                => new(Payload.UserName, Payload.PassWord, Payload.Shipper, Payload.Image, Payload.Role);
        }
    }
}
