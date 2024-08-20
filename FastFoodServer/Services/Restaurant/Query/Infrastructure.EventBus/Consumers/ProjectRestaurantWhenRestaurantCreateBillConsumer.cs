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
    public class ProjectRestaurantWhenRestaurantCreateBillConsumer : Consumer<DomainEvent.RestaurantCreateBill>
    {
        public ProjectRestaurantWhenRestaurantCreateBillConsumer(IInteractor<DomainEvent.RestaurantCreateBill> interactor) : base(interactor)
        {
        }
    }
}
