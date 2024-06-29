using Application.DepedencyInjection.Extensions;
using Infrastructure.EventStore.DependencyInjection.Extensions;
using Infrastructure.MessageBus.DependencyInjection.Extensions;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices((context, services) =>
{
    services.AddConfigurationMasstransit();

    services.AddEventBusGateway();

    services.AddEventStoreGateway();

    services.AddApplicationService();

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
