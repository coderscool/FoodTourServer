using Application.Abstractions.Gateways;
using Application.Abstractions;
using Contracts.Services.Dish;
using GrpcService1.Services;
using Infrastructure.Projection;
using Infrastructure.Projection.Abstractions;
using MongoDB.Driver;
using Application.UseCases.Events;
using Infrastructure.EventBus.DependencyInjection.Extensions;
using Infrastructure.ElasticSearch.DependencyInjection.Extensions;
using Application.UseCases.Queries;
using Infrastructure.ElasticSearch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IProjectionGateway<>), typeof(ProjectionGateway<>));
builder.Services.AddScoped(typeof(IElasticSearchGateway<>), typeof(AzureSearchGateway<>));
builder.Services.AddScoped<IProjectDishWhenDishChangedInteractor, ProjectDishWhenDishChangedInteractor>();
builder.Services.AddScoped<IFindInteractor<Query.ListDishTredingQuery, Projection.Dishs>, GetListDishTrendingInteractor>();
builder.Services.AddScoped<IInteractor<Query.DishDetailsById, Projection.Dishs>, GetDishDetailInteractor>();
builder.Services.AddScoped<IFindInteractor<Query.DishRestaurantQuery, Projection.Dishs>, GetListDishRestaurantInteractor>();
builder.Services.AddScoped<IPagedInteractor<Query.SearchListDish, Projection.Dishs>, SearchListDishInteractor>();
builder.Services.AddConfigurationMasstransit();
builder.Services.AddAzureSearch(builder.Configuration);
builder.Services.AddTransient<IMongoDbContext, ProjectionDbContext>();
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient("mongodb+srv://vhp:Sasori%40123@foodtour-mongodb.global.mongocluster.cosmos.azure.com/?tls=true&authMechanism=SCRAM-SHA-256&retrywrites=false&maxIdleTimeMS=120000"));
builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<DisherService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
