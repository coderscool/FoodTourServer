using Application.Abstractions;
using Contracts.Services.Restaurant;
using Infrastructure.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventBus.Consumers
{
    public class ProjectDeliveryWhenDeliveryChangedConsumer : Consumer<DomainEvent.RestaurantReply>
    {
        public ProjectDeliveryWhenDeliveryChangedConsumer(IInteractor<DomainEvent.RestaurantReply> interactor) : base(interactor)
        {
        }
    }
}
