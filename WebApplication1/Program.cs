using WebApi.DependencyInjection.Extensions;
using WebApi.DependencyInjection.Options;
using WebApplication1.APIs.Account;
using WebApplication1.APIs.Delivery;
using WebApplication1.APIs.Dish;
using WebApplication1.APIs.Identities;
using WebApplication1.APIs.Order;
using WebApplication1.APIs.ShoppingCart;
using WebApplication1.APIs.Statistic;
using WebApplication1.DependencyInjection.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices((context, services) =>
{
    services.AddEndpointsApiExplorer();
    services.AddConfigurationMasstransit(builder.Configuration);
    services.AddConfigurationJwtBeerer(builder.Configuration);

    services.AddIdentityGrpcClient();
    services.AddAccountGrpcClient();
    services.AddDishGrpcClient();
    services.AddShoppingCartGrpcClient();
    services.AddOrderGrpcClient();
    services.AddDeliveryGrpcClient();
    services.AddStatisticGrpcClient();

    services.ConfigureIdentityGrpcClientOptions(
            context.Configuration.GetSection(nameof(IdentityGrpcClientOptions)));

    services.ConfigureAccountGrpcClientOptions(
            context.Configuration.GetSection(nameof(AccountGrpcClientOptions)));

    services.ConfigureDishGrpcClientOptions(
            context.Configuration.GetSection(nameof(DishGrpcClientOptions)));

    services.ConfigureShoppingCartGrpcClientOptions(
            context.Configuration.GetSection(nameof(ShoppingCartGrpcClientOptions)));

    services.ConfigureOrderGrpcClientOptions(
            context.Configuration.GetSection(nameof(OrderGrpcClientOptions)));

    services.ConfigureDeliveryGrpcClientOptions(
            context.Configuration.GetSection(nameof(DeliveryGrpcClientOptions)));

    services.ConfigureStatisticGrpcClientOptions(
            context.Configuration.GetSection(nameof(StatisticGrpcClientOptions)));

    services.AddSwaggerGen();
});
var app = builder.Build();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapDishApiV1();
app.MapOrderApiV1();
app.MapAccountApiV1();
app.MapDeliveryApiV1();
app.MapIdentityApiV1();
app.MapStatisticApiV1();
app.MapShoppingCartApiV1();

app.UsePathBase("/web-api");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}