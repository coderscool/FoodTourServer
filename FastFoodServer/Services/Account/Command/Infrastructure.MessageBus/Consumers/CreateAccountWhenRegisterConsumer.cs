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
    public class CreateAccountWhenRegisterConsumer : Consumer<DomainEvent.RegisterEvent>
    {
        public CreateAccountWhenRegisterConsumer(IInteractor<DomainEvent.RegisterEvent> interactor) : base(interactor)
        {
        }
    }
}
