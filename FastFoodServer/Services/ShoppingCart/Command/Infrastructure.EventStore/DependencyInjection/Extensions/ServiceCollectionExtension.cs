using Application.Abstractions.Gateways;
using Domain.Abstractions.EventStore;
using Infrastructure.EventStore.Contexts;
using Microsoft.EntityFrameworkCore;
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
            => services.AddScoped<IEventStoreGateway, EventStoreGateway>()
                       .AddTransient<IEventStoreRepository, EventStoreRepository>();

        public static IServiceCollection AddConfigurationStoreEvent(this IServiceCollection services)
        {
            var conn = "Data Source=MSI; Initial Catalog=FastFood/Cart; User id=sa; Password=vhp; TrustServercertificate=true";
            services.AddDbContext<EventStoreDbContext>(options =>
                options.UseSqlServer(conn, b => b.MigrationsAssembly("WorkerService1")));
            return services;
        }
    }
}
