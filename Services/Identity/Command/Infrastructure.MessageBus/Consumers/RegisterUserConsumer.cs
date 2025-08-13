using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class RegisterUserConsumer : Consumer<Command.RegisterUser>
    {
        public RegisterUserConsumer(IInteractor<Command.RegisterUser> interactor) : base(interactor)
        {
        }
    }
}
