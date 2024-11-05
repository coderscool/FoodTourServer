using Application.Abstractions;
using Application.Services;
using Contracts.Services.Statistic;
using Microsoft.Extensions.DependencyInjection;
using Identity = Contracts.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Events;
using Dish = Contracts.Services.Dish;
using Restaurant = Contracts.Services.Restaurant;


namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Identity.DomainEvent.RegisterEvent>, CreateStatisticWhenRegisterInteractor>()
                       .AddScoped<IInteractor<Dish.DomainEvent.DishCreate>, UpdateNumberDishWhenDishCreateInteractor>()
                       .AddScoped<IInteractor<Restaurant.DomainEvent.RestaurantReply>, UpdateRevanueWhenRestaurantReplyInteractor>();
    }
}
