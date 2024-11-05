using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class CreateStatisticWhenRegisterConsumer : Consumer<DomainEvent.RegisterEvent>
    {
        public CreateStatisticWhenRegisterConsumer(IInteractor<DomainEvent.RegisterEvent> interactor) : base(interactor)
        {
        }
    }
}
