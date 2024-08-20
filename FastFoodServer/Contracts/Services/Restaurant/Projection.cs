using Contracts.Abstractions.DataTransferObject;
using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Restaurant
{
    public static class Projection
    {
        public class Restaurant : IProjection
        {
            public string Id { get; set; }
            public string RestaurantId { get; set; }
            public string CustomerId { get; set; }
            public string DishId { get; set; }
            public Dto.Person Customer { get; set; }
            public string Name { get; set; }
            public long Price { get; set; }
            public int Quantity { get; set; }
            public int Time { get; set; }
            public bool Status { get; set; }
            public DateTime Date { get; set; }
        }

    }
}
