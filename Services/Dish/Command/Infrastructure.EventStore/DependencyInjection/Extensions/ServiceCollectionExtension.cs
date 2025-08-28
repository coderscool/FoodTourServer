using Application.Abstractions.Gateways;
using Domain.Abstractions.EventStore;
using Infrastructure.EventStore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EventStore.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEventStoreGateway(this IServiceCollection services)
            => services.AddScoped<IEventStoreGateway, EventStoreGateway>()
                       .AddTransient<IEventStoreRepository, EventStoreRepository>();

        public static IServiceCollection AddConfigurationStoreEvent(this IServiceCollection services)
        {
            var conn = "Server=vhpsqlserver.database.windows.net; Database=foodtour_dish; User id=vhp; Password=Sasori@123; TrustServercertificate=true";
            services.AddDbContext<EventStoreDbContext>(options =>
                options.UseSqlServer(conn, b => b.MigrationsAssembly("WorkerService1")));
            return services;
        }
    }
}
