using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DishItem
    {
        public DishItem(string id, string restaurantId, Dto.DtoDish dish, Dto.DtoPrice price, int quantity, Dto.DtoSearch search) 
        { 
            Id = id;
            RestaurantId = restaurantId;
            Dish = dish;
            Price = price;
            Search = search;
            Quantity = quantity;
        }
        public string Id { get; }
        public string RestaurantId { get; }
        public Dto.DtoDish Dish { get; }
        public Dto.DtoPrice Price { get; }
        public Dto.DtoSearch Search { get; }
        public int Quantity { get; private set; }

        public void UpdateQuantity(int quantity)
            => Quantity += quantity;
    }
}
