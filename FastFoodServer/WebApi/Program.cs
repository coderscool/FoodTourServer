using Contracts.Services.Dish;
using Nest;
using WebApi.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddConfigurationMasstransit(builder.Configuration);
builder.Services.AddConfigurationJwtBeerer(builder.Configuration);

var url = "http://localhost:9200";
var defaulIndex = "dish";

var setting = new ConnectionSettings();
setting.DefaultMappingFor<Projection.Dish>(x => x.IndexName("dish"));


var client = new ElasticClient(setting);

builder.Services.AddSingleton<IElasticClient>(client);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
           options.WithOrigins("http://localhost:5173")
           .AllowAnyHeader()
           .AllowAnyMethod());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
