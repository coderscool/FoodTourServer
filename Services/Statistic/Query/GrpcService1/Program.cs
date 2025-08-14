using Application.Abstractions.Gateways;
using GrpcService1.Services;
using Infrastructure.Projection;
using Infrastructure.Projection.Abstractions;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using MongoDB.Driver;
using Application.UseCases.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped<IUpdateStatisticWhenStatisticChangedInteractor, UpdateStatisticWhenStatisticChangedInteractor>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<StatisticerService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
