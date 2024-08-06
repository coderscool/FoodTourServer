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
    public class RequestRestaurantWhenPaymentRequestInteractor : IInteractor<Order.DomainEvent.OrderConfirm>
    {
        private readonly IApplicationService _applicationService;
        private readonly IScheduleNotification _schedule;
        public RequestRestaurantWhenPaymentRequestInteractor(IApplicationService applicationService,
            IScheduleNotification schedule) 
        {
            _applicationService = applicationService;
            _schedule = schedule;
        }
        public async Task InteractAsync(Order.DomainEvent.OrderConfirm @event, CancellationToken cancellationToken)
        {
            Console.WriteLine("requestpayment");
            Restaurant restaurant = new();
            //restaurant.Handle(Command.CreateBillRestaurant { })
            await _schedule.AddScheduleNotification(restaurant.AggregateId, 1, cancellationToken);
        }
    }
}
