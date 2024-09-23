using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Account = Contracts.Services.Account;
using Restaurant = Contracts.Services.Restaurant;
using Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Events;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.AddItemOrder>, AddItemOrderInteractor>()
                       .AddScoped<IInteractor<Account.DomainEvent.PaymentRequest>, ConfirmOrderWhenPaymentRequestInteractor>()
                       .AddScoped<IInteractor<Restaurant.DomainEvent.RestaurantReply>, UpdateStatusWhenRestaurantReply>();
    }
}
