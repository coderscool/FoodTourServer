﻿using Application.Abstractions;
using Application.Services;
using Application.UseCases.Events;
using Contracts.Services.Order;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<DomainEvent.OrderConfirm>, NotificationWhenOrderConfirmInteractor>();

        public static IServiceCollection AddHangfire(this IServiceCollection services)
            => services.AddHangfire(config => config.UseMemoryStorage())
                       .AddHangfireServer();
    }
}
