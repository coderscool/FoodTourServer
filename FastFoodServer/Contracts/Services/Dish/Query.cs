using Contracts.Abstractions.Messages;
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
            public float PriceMin { get; set; }
            public float PriceMax { get; set; }
            public string Location { get; set;} = string.Empty;
        }

        public class DishDetailQuery: IQuery
        {
            public string Id { get; set; }
        }

        public class ListDishTredingQuery : IQuery
        {
        }

        public class DishRestaurantQuery : IQuery
        {
            public string Id { get; set; }
            public int Page { get; set; }
        }
    }
}
