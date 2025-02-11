using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem
    {
        public OrderItem(string id, string restaurantId, string customerId, string dishId, Dto.Person restaurant,
            Dto.Person customer, string name, long price, int quantity, int time, bool status, bool active, DateTime date) 
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
            Active = active;
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
        public bool Status { get; private set; }
        public bool Active { get; private set; }
        public DateTime Date { get; }

        public void UpdateStatus(bool status)
        {
            Status = status;
            Active = true;
        }
    }
}
