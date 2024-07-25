using Application.Abstractions;
using Application.Services;
using Application.UseCases.Commands;
using Contracts.Services.ShoppingCart;
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
                       .AddScoped<IInteractor<Command.AddCartItem>, AddCartItemInteractor>()
                       .AddScoped<IInteractor<Command.CheckAndRemoveDishCart>, RemoveDishCartInteractor>()
                       .AddScoped<IInteractor<Command.IncreaseQuantityCart>, IncreaseQuantityCartInteractor>();
    }
}
