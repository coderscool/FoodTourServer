using Contracts.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Dish
{
    public static class Projection
    {
        public class Dish : IProjection 
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Category { get; set; } = string.Empty;
            public string Nation { get; set; } = string.Empty;
            public float Price { get; set; }
            public string Location { get; set; } = string.Empty;
        }
    }
}
