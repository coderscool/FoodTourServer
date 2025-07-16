using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Contracts.Services.ShoppingCart;
using Identity = Contracts.Services.Identity;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Events;

namespace Application.DepedencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
            => services.AddScoped<IApplicationService, ApplicationService>()
                       .AddScoped<IInteractor<Command.AddCartItem>, AddCartItemInteractor>()
                       .AddScoped<IInteractor<Command.CheckAndRemoveDishCart>, RemoveItemCartInteractor>()
                       .AddScoped<IInteractor<Command.ChangedQuantityItemCart>, ChangedQuantityItemCartInteractor>()
                       .AddScoped<IInteractor<DomainEvent.CartCheckedOut>, PublishCartSubmittedWhenCartCheckedOutInteractor>()
                       .AddScoped<IInteractor<Identity.DomainEvent.UserRegister>, CreateCartWhenUserRegisterInteracor>();
    }
}
