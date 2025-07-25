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

            return builder;
        }
    }
}
