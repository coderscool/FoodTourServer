using Application.DependencyInjection.Extensions;
using Infrastructure.EventStore.DependencyInjection.Extensions;
using Infrastructure.MessageBus.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddConfigurationMasstransit();

builder.Services.AddEventBusGateway();

builder.Services.AddEventStoreGateway();

builder.Services.AddApplicationService();

builder.Services.AddHangfire();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
