using Application.Abstractions;
using Application.Services;
using Contracts.Services.Restaurant;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Events
{
    public class CancelOrderWhenExpireRestaurant : IInteractor<DomainEvent.ExpireOrderRestaurant>
    {
        private readonly IApplicationService _applicationService;
        public CancelOrderWhenExpireRestaurant(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(DomainEvent.ExpireOrderRestaurant @event, CancellationToken cancellationToken)
        {
            Console.WriteLine("successsssssss");
            var restaurant = await _applicationService.LoadAggregateAsync<Restaurant>(@event.AggregateId, cancellationToken);
            restaurant.Handle(new Command.ReplyRestaurant(@event.AggregateId, false));
            Console.WriteLine(restaurant);
            await _applicationService.AppendEventsAsync(restaurant, cancellationToken);
        }
    }
}
