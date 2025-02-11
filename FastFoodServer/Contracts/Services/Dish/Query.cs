using Contracts.Abstractions.Messages;
using Contracts.Services.Dish.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Query
    {
        public class SearchDishDetail : IQuery
        {
            public string Name { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public string Nation { get; set; } = string.Empty;
            public int Page { get; set; }
            public int Size { get; set; }

        }

        public record DishDetailsById(string Id) : IQuery
        {
            public static implicit operator DishDetailsById(DishDetailsByIdRequest request)
                => new( request.Id );
        }

        public class ListDishTredingQuery : IQuery
        {
        }

        public class DishRestaurantQuery : IQuery
        {
            public string Id { get; set; }
            public int Page { get; set; }
            public int Size { get; set; }
        }
    }
}
