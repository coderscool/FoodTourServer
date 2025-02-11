using Application.Abstractions;
using Application.Abstractions.Gateways;
using Application.BackgroundJobs;
using Application.Services;
using Application.UseCases.Commands;
using Application.UseCases.Events;
using Contracts.Services.Restaurant;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order = Contracts.Services.Order;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Order.DomainEvent.OrderConfirm>, RequestRestaurantWhenOrderConfirmInteractor>()
                       .AddScoped<IInteractor<DomainEvent.ExpireOrderRestaurant>, CancelOrderWhenExpireRestaurant>()
                       .AddScoped<IInteractor<Command.ReplyRestaurant>, ReplyRestaurantInteractor>()
                       .AddScoped<IInteractor<Command.CreateRestaurant>, CreateRestaurantInteractor>()
                       .AddScoped<IScheduleNotification, ScheduleNotification>();
    }
}
