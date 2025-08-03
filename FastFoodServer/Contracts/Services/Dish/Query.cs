using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.Services.Dish.Protobuf;

namespace Contracts.Services.Dish
{
    public static class Query
    {
        public record SearchListDish(Paging Paging, string Keyword, string Category, string Nation) : IQuery
        {
            public static implicit operator SearchListDish(SearchDishRequest request)
                => new(request.Paging, request.Keyword, request.Category, request.Nation);

        }

        public record DishDetailsById(string Id) : IQuery
        {
            public static implicit operator DishDetailsById(DishDetailsByIdRequest request)
                => new( request.Id );
        }

        public record ListDishTredingQuery() : IQuery
        {
            public static implicit operator ListDishTredingQuery(FindDishRequest request)
                => new();
        }

        public record DishRestaurantQuery(string Id) : IQuery
        {
            public static implicit operator DishRestaurantQuery(RestaurantIdRequest request)
                 => new(request.Id);
        }
    }
}
