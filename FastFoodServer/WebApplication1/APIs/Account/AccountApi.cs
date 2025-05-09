using Contracts.Services.Account.Protobuf;
using WebApplication1.Abstractions;

namespace WebApplication1.APIs.Account
{
    public static class AccountApi
    {
        public static IEndpointRouteBuilder MapDishApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/api/account/changed-account", ([AsParameters] Commands.ChangedAccount command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapGet("/grid-items", ([AsParameters] Queries.GetListStoreNears query)
                => ApplicationApi.ListAsync<Accounter.AccounterClient, AccountDetails>
                    (query, (client, ct) => client.GetListStoreNearAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
