using Contracts.Services.Dish.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Dish.Validators;

namespace WebApplication1.APIs.Dish
{
    public static class Queries
    {
        public record DishDetailsById(Disher.DisherClient Client, string Id, CancellationToken CancellationToken)
            : Validatable<DishDetailsByIdValidator>, IQuery<Disher.DisherClient>
        {
            public static implicit operator DishDetailsByIdRequest(DishDetailsById request)
                => new() 
                { 
                    Id = request.Id 
                };
        }

        public record SearchListDish(Disher.DisherClient Client, int Limit, int Offset, string Keyword, string Category, string Nation, CancellationToken CancellationToken)
            : Validatable<SearchListDishValidator>, IQuery<Disher.DisherClient>
        {
            public static implicit operator SearchDishRequest(SearchListDish request)
                => new() 
                {
                    Paging = new() { Limit = request.Limit, Offset = request.Offset },
                    Keyword = request.Keyword,
                    Category = request.Category,
                    Nation = request.Nation
                };
        }
        
        public record ListDishTrending(Disher.DisherClient Client, CancellationToken CancellationToken)
            : Validatable<ListDishTrendingValidator>, IQuery<Disher.DisherClient>
        {
            public static implicit operator FindDishRequest(ListDishTrending request)
                => new() { };
        }

        public record DishRestaurant(Disher.DisherClient Client, int Limit, int Offset, string Id, CancellationToken CancellationToken)
            : Validatable<DishRestaurantValidator>, IQuery<Disher.DisherClient>
        {
            public static implicit operator RestaurantIdRequest(DishRestaurant request)
                => new()
                {
                    Id = request.Id
                };
        }
    }
}
