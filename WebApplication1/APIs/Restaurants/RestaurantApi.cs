using WebApplication1.Abstractions;
using WebApplication1.APIs.Identities;

namespace WebApplication1.APIs.Restaurants
{
    public static class RestaurantApi
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/restaurants/";

        public static IEndpointRouteBuilder MapRestaurantApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/create", ([AsParameters] Commands.CreateRestaurant command)
                => ApplicationApi.SendCommandAsync(command));

            return builder;
        }
    }
}
