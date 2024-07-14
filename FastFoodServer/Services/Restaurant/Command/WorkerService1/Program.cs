using Application.DepedencyInjection.Extensions;
using Hangfire;
using Hangfire.MemoryStorage;
using Infrastructure.EventStore.DependencyInjection.Extensions;
using Infrastructure.MessageBus.DependencyInjection.Extensions;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.AddConfigurationMasstransit();

    services.AddEventBusGateway();

    services.AddEventStoreGateway();

    services.AddApplicationService();

    services.AddHangfire(config => config.UseMemoryStorage());

    services.AddHangfireServer();

});

using var host = builder.Build();

try
{
    var environment = host.Services.GetRequiredService<IHostEnvironment>();

    if (environment.IsDevelopment() || environment.IsStaging())
    {
    }

    await host.RunAsync();
}
catch (Exception ex)
{
    await host.StopAsync();
}

