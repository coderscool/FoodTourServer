using Application.Abstractions;
using Restaurant = Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services;
using Domain.Aggregates;
using Contracts.Services.Payment;

namespace Application.UseCases.Events
{
    public class RefundPaymentWhenRestaurantReplyInteractor : IInteractor<Restaurant.DomainEvent.RestaurantReply>
    {
        private readonly IApplicationService _applicationService;
        public RefundPaymentWhenRestaurantReplyInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Restaurant.DomainEvent.RestaurantReply @event, CancellationToken cancellationToken)
        {
            if(@event.Status == true)
            {
                var restaurant = await _applicationService.LoadAggregateAsync<Payment>(@event.RestaurantId, cancellationToken);
                restaurant.Handle(new Command.RefundPayment(@event.RestaurantId, @event.Price, @event.Quantity));
                await _applicationService.AppendEventsAsync(restaurant, cancellationToken);
            }
            else
            {
                var restaurant = await _applicationService.LoadAggregateAsync<Payment>(@event.CustomerId, cancellationToken);
                restaurant.Handle(new Command.RefundPayment(@event.CustomerId, @event.Price, @event.Quantity));
                await _applicationService.AppendEventsAsync(restaurant, cancellationToken);
            }
        }
    }
}
