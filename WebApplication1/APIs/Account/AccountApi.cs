using Contracts.Services.Account.Protobuf;
using WebApplication1.Abstractions;

namespace WebApplication1.APIs.Account
{
    public static class AccountApi
    {
        public static IEndpointRouteBuilder MapAccountApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/api/account/store-near", ([AsParameters] Queries.GetListStoreNears query)
                => ApplicationApi.FindAsync<Accounter.AccounterClient, AccountSellerDetail>
                    (query, (client, ct) => client.GetListStoreNearAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/account/search", ([AsParameters] Queries.SearchListStore query)
                => ApplicationApi.ListAsync<Accounter.AccounterClient, AccountSellerDetail>
                    (query, (client, ct) => client.SearchListStoreAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/account/seller", ([AsParameters] Queries.GetAccountId query)
                => ApplicationApi.GetAsync<Accounter.AccounterClient, AccountSellerDetail>
                    (query, (client, ct) => client.GetAccountSellerAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/account/user", ([AsParameters] Queries.GetAccountId query)
                => ApplicationApi.GetAsync<Accounter.AccounterClient, AccountUserDetail>
                    (query, (client, ct) => client.GetAccountUserAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/account/shipper", ([AsParameters] Queries.GetAccountId query)
                => ApplicationApi.GetAsync<Accounter.AccounterClient, AccountShipperDetail>
                    (query, (client, ct) => client.GetAccountShipperAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
