using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using Contracts.Services.Cart.Protobuf;


namespace Contracts.Services.ShoppingCart
{
    public static class Projection
    {
        public record CartItem(string Id, string CustomerId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, 
            Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note, bool CheckOut, long Version) : IProjection
        {
            public static implicit operator CartItemDetail(CartItem cart)
                => new()
                {
                    Id = cart.Id,
                    CustomerId = cart.CustomerId,
                    RestaurantId = cart.RestaurantId,
                    DishId = cart.DishId,
                    Restaurant = cart.Restaurant,
                    Dish = cart.Dish,
                    Price = cart.Price,
                    Quantity = cart.Quantity,
                    Note = cart.Note,
                    CheckOut = cart.CheckOut
                };
        }

    }
}
