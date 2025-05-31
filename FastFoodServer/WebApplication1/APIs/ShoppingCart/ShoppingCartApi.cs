using WebApplication1.Abstractions;

namespace WebApplication1.APIs.ShoppingCart
{
    public static class ShoppingCartApi
    {
        public static IEndpointRouteBuilder MapShoppingCartApiV1(this IEndpointRouteBuilder builder)
        {
            builder.MapPost("api/shoppingcart/create", ([AsParameters] Commands.CreateCart command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("api/shoppingcart/change-customer", ([AsParameters] Commands.ChangeCustomerCart command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("api/shoppingcart/change-description", ([AsParameters] Commands.ChangeDescriptionCart command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("api/shoppingcart/remove-cart", ([AsParameters] Commands.RemoveCart command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("api/shoppingcart/add-cart-item", ([AsParameters] Commands.AddCartItem command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("api/shoppingcart/remove-cart-item", ([AsParameters] Commands.CheckAndRemoveDishCart command)
                => ApplicationApi.SendCommandAsync(command));

            builder.MapPost("api/shoppingcart/changed-quantity", ([AsParameters] Commands.ChangedQuantityItemCart command)
                => ApplicationApi.SendCommandAsync(command));

            return builder;
        }
    }
}
