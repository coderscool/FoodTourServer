using WebApi.DependencyInjection.Extensions;
using WebApi.DependencyInjection.Options;
using WebApplication1.APIs;
using WebApplication1.APIs.Restaurants;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices((context, services) =>
{
    services.AddEndpointsApiExplorer();
    services.AddConfigurationMasstransit(builder.Configuration);
    services.AddConfigurationJwtBeerer(builder.Configuration);

    services.AddIdentityGrpcClient();

    services.ConfigureIdentityGrpcClientOptions(
            context.Configuration.GetSection(nameof(IdentityGrpcClientOptions)));

    services
        .AddApiVersioning(options => options.ReportApiVersions = true)
        .AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

    services.AddSwaggerGen();
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};


app.MapIdentityApiV1();
app.MapRestaurantApiV1();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}