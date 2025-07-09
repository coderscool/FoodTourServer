using Contracts.Services.Identity.Protobuf;
using WebApplication1.Abstractions;

namespace WebApplication1.APIs.Identities
{
    public static class IdentityApi
    {
        public static IEndpointRouteBuilder MapIdentityApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/sign-in", ([AsParameters] Queries.SignIn query)
                => ApplicationApi.GetAsync<Identiter.IdentiterClient, IdentityDetails>
                    (query, (client, cancellationToken) => client.LoginAsync(query, cancellationToken: cancellationToken)));

            builder.MapPost("/sign-up/user", ([AsParameters] Commands.RegisterUser command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("/sign-up/seller", ([AsParameters] Commands.RegisterSeller command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("/sign-up/shipper", ([AsParameters] Commands.RegisterShipper command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapGet("/restaurant-items", ([AsParameters] Queries.ListRestaurantItems query)
                => ApplicationApi.ListAsync<Identiter.IdentiterClient, IdentityDetails>
                    (query, (client, ct) => client.ListRestaurantItemsAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
