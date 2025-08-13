using Application.Abstractions.Gateways;
using Domain.Abstractions.EventStore;
using Infrastructure.EventStore.Contexts;
using Infrastructure.EventStore.DependencyInjection.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.EventStore.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEventStoreGateway(this IServiceCollection services)
            => services.AddScoped<IEventStoreGateway, EventStoreGateway>()
                       .AddTransient<IEventStoreRepository, EventStoreRepository>();

        public static void AddConfigurationStoreEvent(this IServiceCollection services)
        {
            services.AddDbContextPool<DbContext, EventStoreDbContext>((provider, builder) =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var options = provider.GetRequiredService<IOptionsMonitor<SqlServerRetryOptions>>();

                builder
                    .EnableDetailedErrors()
                    .UseSqlServer(
                        connectionString: configuration.GetConnectionString("EventStore"),
                        sqlServerOptionsAction: sqlOptions =>
                        {
                            sqlOptions.ExecutionStrategy(dependencies =>
                                new SqlServerRetryingExecutionStrategy(
                                    dependencies,
                                    options.CurrentValue.MaxRetryCount,
                                    options.CurrentValue.MaxRetryDelay,
                                    options.CurrentValue.ErrorNumbersToAdd));

                            sqlOptions.EnableRetryOnFailure();

                            sqlOptions.MigrationsAssembly("WorkerService1");
                        });
            });
        }

        public static OptionsBuilder<SqlServerRetryOptions> ConfigureSqlServerRetryOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<SqlServerRetryOptions>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();

        public static OptionsBuilder<EventStoreOptions> ConfigureEventStoreOptions(this IServiceCollection services, IConfigurationSection section)
            => services
                .AddOptions<EventStoreOptions>()
                .Bind(section)
                .ValidateDataAnnotations()
                .ValidateOnStart();
    }
}
