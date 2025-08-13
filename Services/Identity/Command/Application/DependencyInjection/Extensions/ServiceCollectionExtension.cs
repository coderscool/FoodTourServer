using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Contracts.Services.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.RegisterUser>, RegisterUserInteractor>()
                       .AddScoped<IInteractor<Command.RegisterSeller>, RegisterSellerInteractor>()
                       .AddScoped<IInteractor<Command.RegisterShipper>, RegisterShipperInteractor>();
    }
}
