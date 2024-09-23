using GrpcService1.Services;
using Infrastructure.Projection;
using Infrastructure.Projection.Abstractions;
using MongoDB.Driver;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using Contracts.Services.Account;
using Application.Abstractions;
using Application.UseCases.Events;
using Application.Abstractions.Gateways;
using Application.UseCases.Queries;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped<IInteractor<DomainEvent.AccountCreate>, ProjectAccountWhenRegisterInteractor>();
builder.Services.AddScoped<IInteractor<DomainEvent.PaymentRequest>, ProjectAccountWhenPaymentRequestInteractor>();
builder.Services.AddScoped<IInteractor<DomainEvent.PaymentRefund>, ProjectAccountWhenPaymentRefundInteractor>();
builder.Services.AddScoped<IInteractor<Query.GetAccountId, Projection.Account>, GetBudgetAccountInteractor>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AccounterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
