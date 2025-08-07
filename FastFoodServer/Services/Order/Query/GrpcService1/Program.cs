using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Order;
using GrpcService1.Services;
using Infrastructure.Projection.Abstractions;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using MongoDB.Driver;
using Infrastructure.Projection;
using Application.UseCases.Events;
using Application.UseCases.Queries;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped<IProjectOrderItemWhenOrderChangedInteractor, ProjectOrderItemWhenOrderChangedInteractor>();
builder.Services.AddScoped<IPagedInteractor<Query.GetOrderSellerQuery, Projection.OrderGroup>, GetListOrderSeller>();
builder.Services.AddScoped<IPagedInteractor<Query.GetOrderUserQuery, Projection.OrderGroup>, GetListOrderUser>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<OrdererService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.Run();
