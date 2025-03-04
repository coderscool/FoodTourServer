using Application.Abstractions;
using Application.BackgroundJobs;
using Application.Services;
using Contracts.Services.Restaurant;
using Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order = Contracts.Services.Order;

namespace Application.UseCases.Events
{
    public class RequestRestaurantWhenOrderConfirmInteractor : IInteractor<Order.DomainEvent.OrderConfirmSuccess>
    {
        private readonly IApplicationService _applicationService;
        private readonly IScheduleNotification _schedule;
        public RequestRestaurantWhenOrderConfirmInteractor(IApplicationService applicationService,
            IScheduleNotification schedule) 
        {
            _applicationService = applicationService;
            _schedule = schedule;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderConfirmSuccess @event, CancellationToken cancellationToken)
        {
            foreach(var item in @event.Items)
            {
                Restaurant restaurant = new();
                restaurant.Handle(new Command.CreateBillRestaurant(@event.OrderId, item.RestaurantId, @event.CustomerId, item.DishId,
                    @event.Customer, item.Dish, item.Price, item.Quantity, item.Note, item.Time, @event.Date));
                await _applicationService.AppendEventsAsync(restaurant, cancellationToken);
                await _schedule.AddScheduleNotification(@event.OrderId, item.Time, cancellationToken);
            }
        }
    }
}
