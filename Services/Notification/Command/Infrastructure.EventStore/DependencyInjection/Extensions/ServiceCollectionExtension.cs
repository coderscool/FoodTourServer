using Application.Abstractions.Gateways;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EventStore.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEventStoreGateway(this IServiceCollection services)
            => services.AddScoped<IEventStoreGateway, EventStoreGateway>();
    }
}
