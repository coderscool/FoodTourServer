using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Dish
{
    public static class Projection
    {
        public record Dishs(string Id, string RestaurantId, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, ushort Quantity, Dto.DtoSearch Search, bool Hidden, long Version) : IProjection
        {
            public static implicit operator Protobuf.DishSearch(Dishs dish)
                => new()
                {
                    Id = dish.Id,
                    RestaurantId = dish.RestaurantId,
                    Dish = dish.Dish,
                    Price = dish.Price,
                    Search = dish.Search,
                    Hidden = dish.Hidden
                };

            public static implicit operator Protobuf.DishDetails(Dishs dish)
                => new()
                {
                    Id = dish.Id,
                    RestaurantId = dish.RestaurantId,
                    Dish = dish.Dish,
                    Extra = { dish.Extra.Select(extra => (Abstractions.Protobuf.ExtraFoodDetail)extra) },
                    Price = dish.Price,
                    Quantity = dish.Quantity,
                    Search = dish.Search
                };

            public static implicit operator Protobuf.DishTrending(Dishs dish)
                => new()
                {
                    Id = dish.Id,
                    RestaurantId = dish.RestaurantId,
                    Dish = dish.Dish,
                    Price = dish.Price,
                    Quantity = dish.Quantity,
                };
        }
    }
}
