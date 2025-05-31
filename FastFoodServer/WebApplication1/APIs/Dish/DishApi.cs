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

            builder.MapGet("/api/dish/detail", ([AsParameters] Queries.DishDetailsById query)
                => ApplicationApi.GetAsync<Disher.DisherClient, DishDetails>
                    (query, (client, ct) => client.GetDishDetailsByIdAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/dish/search", ([AsParameters] Queries.SearchListDish query)
                => ApplicationApi.ListAsync<Disher.DisherClient, DishDetails>
                    (query, (client, ct) => client.SearchListDishAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/dish/restaurant", ([AsParameters] Queries.DishRestaurant query)
                => ApplicationApi.ListAsync<Disher.DisherClient, DishDetails>
                    (query, (client, ct) => client.GetListDishByRestaurantIdAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/dish/trending", ([AsParameters] Queries.ListDishTrending query)
                => ApplicationApi.FindAsync<Disher.DisherClient, DishDetails>
                    (query, (client, ct) => client.FindDishTrendingAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
