using GrpcService1.Services;
using Infrastructure.Projection;
using Infrastructure.Projection.Abstractions;
using MongoDB.Driver;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using Application.Abstractions.Gateways;
using Infrastructure.ElasticSearch.DependencyInjection.Extensions;
using Application.UseCases.Events;
using Infrastructure.ElasticSearch;
using Application.Abstractions;
using Contracts.Services.Account;
using Application.UseCases.Queries;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped(typeof(IElasticSearchGateway<>), typeof(ElasticSearchGateway<>));
builder.Services.AddScoped<IProjectAccountWhenAccountChangedInteractor, ProjectAccountWhenAccountChangedInteractor>();
builder.Services.AddScoped<IFindInteractor<Query.PositionStore, Projection.Account>, GetListStoreNear>();
builder.Services.AddScoped<IPagedInteractor<Query.SearchQuery, Projection.AccountES>, SearchListStore>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddElasticSearch();
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb://localhost:27017"));
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<AccounterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
