using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Res
{
    public class RestaurantItem
    {
        public RestaurantItem(string id, string restaurantId, string customerId, string dishId, Dto.DtoPrice price, int quantity, string status)
        {
            Id = id;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            DishId = dishId;
            Price = price;
            Quantity = quantity;
            Status = status;
        }
        public string Id { get; }
        public string RestaurantId { get; }
        public string CustomerId { get; }
        public string DishId { get; }
        public Dto.DtoPrice Price { get; }
        public int Quantity { get; }
        public string Status { get; private set; }

        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }
}
