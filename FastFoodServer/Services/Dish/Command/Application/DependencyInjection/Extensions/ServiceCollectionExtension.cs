using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Contracts.Services.Dish;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.CreateDish>, CreateDishInteractor>()
                       .AddScoped<IInteractor<Command.UpdatePriceDish>, UpdatePriceDishInteractor>();
    }
}
