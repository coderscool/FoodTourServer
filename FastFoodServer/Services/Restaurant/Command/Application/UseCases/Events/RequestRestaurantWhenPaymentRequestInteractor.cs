using Application.Abstractions;
using Application.BackgroundJobs;
using Application.Services;
using Contracts.Services.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment = Contracts.Services.Account;

namespace Application.UseCases.Events
{
    public class RequestRestaurantWhenPaymentRequestInteractor : IInteractor<Payment.DomainEvent.PaymentRequest>
    {
        private readonly IApplicationService _applicationService;
        private readonly IScheduleNotification<DomainEvent.ExpireOrderRestaurant> _schedule;
        public RequestRestaurantWhenPaymentRequestInteractor(IApplicationService applicationService,
            IScheduleNotification<DomainEvent.ExpireOrderRestaurant> schedule) 
        {
            _applicationService = applicationService;
            _schedule = schedule;
        }
        public async Task InteractAsync(Payment.DomainEvent.PaymentRequest message, CancellationToken cancellationToken)
        {
            Console.WriteLine("requestpayment");
            _schedule.AddScheduleNotification(new DomainEvent.ExpireOrderRestaurant("1", 1 ), 1, cancellationToken);
        }
    }
}
