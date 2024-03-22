using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Abstractions.DataTransferObject
{
    public static class Dto
    {
        public record Price(string Cost, float Discount);
        public record Dish(string Description, string Name, string Category, string Image);
        public record DishItem(Guid Id, Dish Dish, Price Price);
    }
}
