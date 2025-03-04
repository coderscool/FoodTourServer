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
        public OrderItem(string itemId, string restaurantId, string dishId, Dto.DtoPerson restaurant,
            Dto.DtoDish dish, ushort quantity, string note, Dto.DtoPrice price, ushort time, string status) 
        {
            ItemId = itemId;
            RestaurantId = restaurantId;
            DishId = dishId;
            Restaurant = restaurant;
            Dish = dish;
            Quantity = quantity;
            Note = note;
            Price = price;
            Time = time;
            Status = status;
        }
        public string ItemId { get; }
        public string RestaurantId { get; }
        public string DishId { get; }
        public Dto.DtoPerson Restaurant { get; }
        public Dto.DtoDish Dish { get; }
        public ushort Quantity { get; }
        public string Note { get; }
        public Dto.DtoPrice Price { get; }
        public ushort Time { get; }
        public string Status { get; private set; }

        public void UpdateStatus(bool status)
        {
        }

        public static implicit operator OrderItem(Dto.OrderItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Quantity, item.Note, item.Price,
                item.Time, item.Status);

        public static implicit operator Dto.OrderItem(OrderItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Quantity, item.Note, item.Price,
                item.Time, item.Status);
    }
}
