using Application.Abstractions.Gateways;
using GrpcService1.Services;
using Infrastructure.Projection;
using Infrastructure.Projection.Abstractions;
using MongoDB.Driver;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using Application.UseCases.Events;
using Application.Abstractions;
using Contracts.Services.Delivery;
using Application.UseCases.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped<IProjectDeliveryWhenDeliveryChangedInteractor, ProjectDeliveryWhenDeliveryChangedInteractor>();
builder.Services.AddScoped<IInteractor<Query.GetById, Projection.Delivery>, GetDeliveryDetail>();
builder.Services.AddScoped<IPagedInteractor<Query.GetList, Projection.Delivery>, GetListDelivery>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<DeliveryService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
