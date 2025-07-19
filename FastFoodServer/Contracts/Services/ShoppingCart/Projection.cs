using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using Contracts.Services.Cart.Protobuf;


namespace Contracts.Services.ShoppingCart
{
    public static class Projection
    {
        public record CartItem(string Id, string CustomerId, string RestaurantId, string DishId, Dto.DtoDish Dish,
             List<string> Extra, Dto.DtoPrice Price, ushort Quantity, string Note, bool CheckOut, long Version) : IProjection
        {
            public static implicit operator CartItemDetail(CartItem cart)
                => new()
                {
                    Id = cart.Id,
                    CustomerId = cart.CustomerId,
                    RestaurantId = cart.RestaurantId,
                    DishId = cart.DishId,
                    Dish = cart.Dish,
                    Extra = { cart.Extra },
                    Price = cart.Price,
                    Quantity = cart.Quantity,
                    Note = cart.Note,
                    CheckOut = cart.CheckOut
                };
        }

    }
}
