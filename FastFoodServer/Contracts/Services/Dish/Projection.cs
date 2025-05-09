using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Projection
    {
        public record Dishs(string Id, string RestaurantId, Dto.DtoDish Dish, Dto.DtoPrice Price, int Quantity, Dto.DtoSearch Search, long Version) : IProjection
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
