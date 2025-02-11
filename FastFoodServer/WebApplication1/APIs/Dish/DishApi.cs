using Contracts.Services.Dish.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Identities;

namespace WebApplication1.APIs.Dish
{
    public static class DishApi
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/dish/";

        public static IEndpointRouteBuilder MapDishApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/create-dish", ([AsParameters] Commands.CreateDish command)
                => ApplicationApi.SendCommandAsync(command));

            return builder;
        }
    }
}
