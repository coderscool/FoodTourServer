using Application.DependencyInjection.Extensions;
using Infrastructure.EventStore.DependencyInjection.Extensions;
using Infrastructure.Hubs;
using Infrastructure.Hubs.Abstractions;
using Infrastructure.MessageBus.DependencyInjection.Extensions;
using Microsoft.AspNetCore.SignalR;
using SignalRNotification.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigurationMasstransit();

builder.Services.AddEventBusGateway();

builder.Services.AddEventStoreGateway();

builder.Services.AddApplicationService();

builder.Services.AddScoped<IQueueService, QueueService>();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseRouting();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<NotificationHub>("/notification");
});

app.Run();
