using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem
    {
        public CartItem(string itemId, string restaurantId, string dishId, Dto.DtoPerson restaurant, Dto.DtoDish dish, ushort quantity, Dto.DtoPrice price, ushort time, string note) 
        {
            ItemId = itemId;
            RestaurantId = restaurantId;
            DishId = dishId;
            Restaurant = restaurant;
            Dish = dish;
            Quantity = quantity;
            Price = price;
            Time = time;
            Note = note;
        }
        public string ItemId { get; }
        public string RestaurantId { get; }
        public string DishId { get; }
        public Dto.DtoPerson Restaurant { get; }
        public Dto.DtoDish Dish { get; }
        public ushort Quantity { get; private set; }
        public Dto.DtoPrice Price { get; }
        public ushort Time { get; }
        public string Note { get; }

        public void Increase(ushort quantity)
        => Quantity += quantity;

        public void Decrease(ushort quantity)
            => Quantity += quantity;

        public static implicit operator CartItem(Dto.CartItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Quantity, item.Price, item.Time, item.Note);

        public static implicit operator Dto.CartItem(CartItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Quantity, item.Price, item.Time, item.Note);
    }
}
