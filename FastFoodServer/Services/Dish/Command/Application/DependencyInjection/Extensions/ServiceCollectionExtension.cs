using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Contracts.Services.Dish;
using Order = Contracts.Services.Order;

using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Events;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.CreateDish>, CreateDishInteractor>()
                       .AddScoped<IInteractor<Command.UpdateDish>, UpdateDishInteractor>()
                       .AddScoped<IInteractor<Command.HiddenDish>, HiddenDishInteractor>()
                       .AddScoped<IInteractor<Order.SummaryEvent.OrderTransport>, UpdateQuantityDishInteractor>();
    }
}
