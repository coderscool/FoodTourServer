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
    public class ProjectRestaurantWhenRestaurantReplyConsumer : Consumer<DomainEvent.RestaurantReply>
    {
        public ProjectRestaurantWhenRestaurantReplyConsumer(IInteractor<DomainEvent.RestaurantReply> interactor) : base(interactor)
        {
        }
    }
}
