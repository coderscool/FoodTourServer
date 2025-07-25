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

            return builder;
        }
    }
}
