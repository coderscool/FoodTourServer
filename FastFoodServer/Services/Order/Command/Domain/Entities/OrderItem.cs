using Contracts.Abstractions.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class OrderItem
    {
        public OrderItem(string id, string restaurantId, string customerId, string dishId, Dto.Person restaurant,
            Dto.Person customer, string name, long price, int quantity, int time, string status, DateTime date) 
        {
            Id = id;
            RestaurantId = restaurantId; 
            CustomerId = customerId; 
            DishId = dishId;
            Restaurant = new PersonDetail(restaurant.Name, restaurant.Phone, restaurant.Address);
            Customer = new PersonDetail(restaurant.Name, restaurant.Phone, restaurant.Address);
            Name = name;
            Price = price;
            Quantity = quantity;
            Time = time;
            Status = status;
            Date = date;
        }
        public string Id { get; }
        public string RestaurantId { get; }
        public string CustomerId { get; }
        public string DishId { get; }
        public PersonDetail Restaurant { get; }
        public PersonDetail Customer { get; }
        public string Name { get; }
        public long Price { get; }
        public int Quantity { get; }
        public int Time { get; }
        public string Status { get; }
        public DateTime Date { get; }
    }
}
