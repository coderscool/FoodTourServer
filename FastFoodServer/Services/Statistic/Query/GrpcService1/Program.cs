using Application.Abstractions.Gateways;
using GrpcService1.Services;
using Infrastructure.Projection;
using Infrastructure.Projection.Abstractions;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using MongoDB.Driver;
using Application.UseCases.Events;
using Application.Abstractions;
using Contracts.Services.Statistic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped<IInteractor<DomainEvent.StatisticCreate>, StatisticSellerCreateInteractor >();
builder.Services.AddScoped<IInteractor<DomainEvent.NumberDishUpdate>, NumberDishUpdateInteractor>();
builder.Services.AddScoped<IInteractor<DomainEvent.RevenueUpdate>, RevenueUpdateInteractor>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
