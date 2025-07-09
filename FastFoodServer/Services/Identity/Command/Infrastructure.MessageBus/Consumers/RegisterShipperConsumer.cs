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
    public class RegisterShipperConsumer : Consumer<Command.RegisterShipper>
    {
        public RegisterShipperConsumer(IInteractor<Command.RegisterShipper> interactor) : base(interactor)
        {
        }
    }
}
