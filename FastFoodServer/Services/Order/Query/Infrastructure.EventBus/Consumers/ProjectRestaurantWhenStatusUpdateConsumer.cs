using Application.Abstractions;
using Contracts.Services.Order;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectRestaurantWhenStatusUpdateConsumer : Consumer<DomainEvent.StatusUpdate>
    {
        public ProjectRestaurantWhenStatusUpdateConsumer(IInteractor<DomainEvent.StatusUpdate> interactor) : base(interactor)
        {
        }
    }
}
