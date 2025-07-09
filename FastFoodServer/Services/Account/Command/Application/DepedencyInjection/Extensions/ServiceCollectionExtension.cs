using Application.Abstractions;
using Application.Services;
using Application.UseCases.Events;
using Microsoft.Extensions.DependencyInjection;
using Identity = Contracts.Services.Identity;


namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Identity.DomainEvent.UserRegister>, CreateAccountUserWhenUserRegisterInteractor>()
                       .AddScoped<IInteractor<Identity.DomainEvent.SellerRegister>, CreateAccountSellerWhenSellerRegisterInteractor>()
                       .AddScoped<IInteractor<Identity.DomainEvent.ShipperRegister>, CreateAccountShipperWhenShipperRegisterInteractor>();
    }
}
