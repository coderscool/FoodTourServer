using Contracts.Services.Identity.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Identities;

namespace WebApplication1.APIs
{
    public static class IdentityApi
    {
        private const string BaseUrl = "/api/v{version:apiVersion}/identities/";

        public static IEndpointRouteBuilder MapIdentityApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/sign-in", ([AsParameters] Queries.SignIn query)
                => ApplicationApi.GetAsync<Identiter.IdentiterClient, UserDetails>
                    (query, (client, cancellationToken) => client.LoginAsync(query, cancellationToken: cancellationToken)));

            builder.MapPost("/sign-up", ([AsParameters] Commands.RegisterUser command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapGet("/restaurant-items", ([AsParameters] Queries.ListRestaurantItems query)
                => ApplicationApi.ListAsync<Identiter.IdentiterClient, UserDetails>
                    (query, (client, ct) => client.ListRestaurantItemsAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
