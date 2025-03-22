using Application.Abstractions;
using Restaurant = Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Aggregates;
using Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class UpdateStatusWhenRestaurantReply : IInteractor<Restaurant.DomainEvent.RestaurantReply>
    {
        private readonly IApplicationService _applicationService;
        public UpdateStatusWhenRestaurantReply(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Restaurant.DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            var order = await _applicationService.LoadAggregateAsync<Order>(@event.Id, cancellationToken);
            order.Handle(new Command.UpdateStatus(@event.Id, @event.Status));
            await _applicationService.AppendEventsAsync(order, cancellationToken);
        }
    }
}
