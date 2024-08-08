using Application.Abstractions;
using Restaurant = Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class UpdateStatusWhenRestaurantReply : IInteractor<Restaurant.DomainEvent.RestaurantReply>
    {
        public async Task InteractAsync(Restaurant.DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            
        }
    }
}
