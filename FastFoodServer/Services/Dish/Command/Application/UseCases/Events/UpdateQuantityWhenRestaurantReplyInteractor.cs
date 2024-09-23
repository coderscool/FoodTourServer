using Application.Abstractions;
using Restaurant = Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Aggregates;
using Contracts.Services.Dish;

namespace Application.UseCases.Events
{
    public class UpdateQuantityWhenRestaurantReplyInteractor : IInteractor<Restaurant.DomainEvent.RestaurantReply>
    {
        private readonly IApplicationService _applicationService;
        public UpdateQuantityWhenRestaurantReplyInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Restaurant.DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            if(@event.Status == true)
            {
                var dish = await _applicationService.LoadAggregateAsync<Dish>(@event.AggregateId, cancellationToken);
                dish.Handle(new Command.UpdateQuantity(@event.AggregateId, @event.Quantity));
                await _applicationService.AppendEventsAsync(dish, cancellationToken);
            }
        }
    }
}
