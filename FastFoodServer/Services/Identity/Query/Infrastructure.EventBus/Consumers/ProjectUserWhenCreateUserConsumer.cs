using Application.Abstractions;
using Contracts.Services.Identity;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectUserWhenCreateUserConsumer : Consumer<DomainEvent.RegisterEvent>
    {

        public ProjectUserWhenCreateUserConsumer(IInteractor<DomainEvent.RegisterEvent> interactor) : base(interactor)
        {

        }
    }
}
