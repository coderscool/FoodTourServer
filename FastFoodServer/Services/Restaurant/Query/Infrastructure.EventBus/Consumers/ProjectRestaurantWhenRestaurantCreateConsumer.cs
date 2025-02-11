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
    public class ProjectRestaurantWhenRestaurantCreateConsumer : Consumer<DomainEvent.RestaurantCreate>
    {
        public ProjectRestaurantWhenRestaurantCreateConsumer(IInteractor<DomainEvent.RestaurantCreate> interactor) : base(interactor)
        {
        }
    }
}
