using Application.Abstractions;
using Contracts.Services.Delivery;
using Infrastructure.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MessageBus.Consumers
{
    public class RequireOrderWhenDeiveryRequireDishConsumer : Consumer<DomainEvent.DeliveryRequireDish>
    {
        public RequireOrderWhenDeiveryRequireDishConsumer(IInteractor<DomainEvent.DeliveryRequireDish> interactor) : base(interactor)
        {
        }
    }
}
