using Contracts.Services.Order.Protobuf;
using WebApplication1.Abstractions;

namespace WebApplication1.APIs.Order
{
    public static class OrderApi
    {
        public static IEndpointRouteBuilder MapOrderApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/api/order/confirm", ([AsParameters] Commands.ConfirmOrder command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("/api/order/complete", ([AsParameters] Commands.CompleteDishOrder command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapGet("/api/order/seller", ([AsParameters] Queries.GetListOrderSeller query)
                => ApplicationApi.ListAsync<Orderer.OrdererClient, OrderSeller>
                    (query, (client, ct) => client.GetListOrderSellerAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/order/user", ([AsParameters] Queries.GetListOrderUser query)
                => ApplicationApi.ListAsync<Orderer.OrdererClient, OrderUser>
                    (query, (client, ct) => client.GetListOrderUserAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
