using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Dish
{
    public static class Projection
    {
        public record Dishs(string Id, string RestaurantId, Dto.DtoDish Dish, List<Dto.ExtraFood> Extra, Dto.DtoPrice Price, int Quantity, Dto.DtoSearch Search, long Version) : IProjection
        {
            public static implicit operator Protobuf.DishDetails(Dishs dish)
                => new()
                {
                    Id = dish.Id,
                    RestaurantId = dish.RestaurantId,
                    Dish = dish.Dish,
                    Price = dish.Price,
                    Quantity = dish.Quantity,
                    Search = dish.Search
                };
        }
    }
}
