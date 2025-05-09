using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using MongoDB.Bson.Serialization.Attributes;
using Contracts.Services.Cart.Protobuf;


namespace Contracts.Services.ShoppingCart
{
    public static class Projection
    {
        public record Cart(string Id, string CustomerId, Dto.DtoPerson Customer, string Description, ulong Total, long Version) : IProjection 
        {
            public static implicit operator CartDetails(Cart cart)
                => new() 
                { 
                    Id = cart.Id, 
                    CustomerId = cart.CustomerId, 
                    Customer = cart.Customer, 
                    Description = cart.Description, 
                    Total = cart.Total
                };
        }

        public record CartItem(string Id, string CartId, string RestaurantId, string DishId, Dto.DtoPerson Restaurant, 
            Dto.DtoDish Dish, Dto.DtoPrice Price, ushort Quantity, string Note, long Version) : IProjection
        {
            public static implicit operator CartItems(CartItem cart)
                => new()
                {
                    Id = cart.Id,
                    CartId = cart.CartId,
                    RestaurantId = cart.RestaurantId,
                    DishId = cart.DishId,
                    Restaurant = cart.Restaurant,
                    Dish = cart.Dish,
                    Price = cart.Price,
                    Quantity = cart.Quantity,
                    Note = cart.Note
                };
        }

    }
}
