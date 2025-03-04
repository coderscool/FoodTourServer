using Application.Abstractions;
using Application.Abstractions.Gateways;
using Application.Services;
using Application.UseCases.Events;
using Contracts.Services.Dish;
using Contracts.Services.Account;
using Microsoft.Extensions.DependencyInjection;
using Order = Contracts.Services.Order;
using Identify = Contracts.Services.Identity;
using Restaurant = Contracts.Services.Restaurant;
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
                       .AddScoped<IInteractor<Identify.DomainEvent.RegisterEvent>, CreateAccountWhenRegisterInteractor>();
    }
}
