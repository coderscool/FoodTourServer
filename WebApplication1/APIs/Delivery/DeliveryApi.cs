using Contracts.Services.Delivery.Protobuf;
using WebApplication1.Abstractions;

namespace WebApplication1.APIs.Delivery
{
    public static class DeliveryApi
    {
        public static IEndpointRouteBuilder MapDeliveryApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("/api/shipper/add", ([AsParameters] Commands.AddShipperDelivery command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("/api/shipper/require", ([AsParameters] Commands.RequireDishDelivery command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapGet("/api/delivery/list", ([AsParameters] Queries.GetListDelivery query)
                => ApplicationApi.ListAsync<Deliverier.DeliverierClient, DeliveryDetail>
                    (query, (client, ct) => client.GetListDeliveryAsync(query, cancellationToken: ct)));

            builder.MapGet("/api/delivery/get", ([AsParameters] Queries.GetDeliveryById query)
                => ApplicationApi.GetAsync<Deliverier.DeliverierClient, DeliveryDetail>
                    (query, (client, ct) => client.GetDeliveryDetailAsync(query, cancellationToken: ct)));

            return builder;
        }
    }
}
