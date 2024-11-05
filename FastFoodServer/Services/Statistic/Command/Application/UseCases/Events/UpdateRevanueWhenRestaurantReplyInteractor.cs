using Application.Abstractions;
using Restaurant = Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Services.Statistic;
using Application.Services;
using Domain.Aggregates;

namespace Application.UseCases.Events
{
    public class UpdateRevanueWhenRestaurantReplyInteractor : IInteractor<Restaurant.DomainEvent.RestaurantReply>
    {
        private readonly IApplicationService _applicationService;
        public UpdateRevanueWhenRestaurantReplyInteractor(IApplicationService applicationService) 
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Restaurant.DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            if(@event.Status == true)
            {
                var statistic = await _applicationService.LoadAggregateAsync<Statistic>(@event.RestaurantId, cancellationToken);
                statistic.Handle(new Command.UpdateRevanue(@event.RestaurantId, @event.Quantity, @event.Price));
                await _applicationService.AppendEventsAsync(statistic, cancellationToken);
            }
        }
    }
}
