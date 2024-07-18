using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public CartItem(string id, string restaurantId, string customerId, string dishId, int amount) 
        {
            Id = id;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            DishId = dishId;
            Amount = amount;
        }
        public string Id { get;}
        public string RestaurantId { get; }
        public string CustomerId { get; }
        public string DishId { get; }
        public int Amount { get; private set; }

        public void Increase(int quantity)
        => Amount += quantity;

        public void Decrease(int quantity)
            => Amount += quantity;
    }
}
