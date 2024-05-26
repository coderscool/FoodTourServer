using Application.Abstractions;
using Application.Abstractions.Gateways;
using Application.Services;
using Application.UseCases.Commands;
using Application.UseCases.Events;
using Contracts.Services.Dish;
using Contracts.Services.Order;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Contracts.Services.Dish.Command.CreateDish>, AddDishInteractor>()
                       .AddScoped<IInteractor<Contracts.Services.Order.DomainEvent.OrderAddItem>, AddNotificationInteractor>();
    }
}
