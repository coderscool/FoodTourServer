using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Application.UseCases.Events;
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
                       .AddScoped<IInteractor<Contracts.Services.Dish.Command.CreateDish>, AddDishInteractor>()
                       .AddScoped<IInteractor<Contracts.Services.Order.DomainEvent.OrderAddItem>, AddNotificationInteractor>()
                       .AddScoped<IInteractor<Contracts.Services.Restaurant.DomainEvent.RestaurantReply>, UpdateQuantityWhenRestaurantReplyInteractor>();
    }
}
