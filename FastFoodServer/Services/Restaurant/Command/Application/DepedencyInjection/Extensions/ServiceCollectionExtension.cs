using Application.Abstractions;
using Application.Abstractions.Gateways;
using Application.BackgroundJobs;
using Application.Services;
using Application.UseCases.Events;
using Contracts.Services.Restaurant;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment = Contracts.Services.Account;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Payment.DomainEvent.PaymentRequest>, RequestRestaurantWhenPaymentRequestInteractor>()
                       .AddScoped<IInteractor<DomainEvent.ExpireOrderRestaurant>, CancelOrderWhenExpireRestaurant>()
                       .AddScoped(typeof(IScheduleNotification<>), typeof(ScheduleNotification<>));
    }
}
