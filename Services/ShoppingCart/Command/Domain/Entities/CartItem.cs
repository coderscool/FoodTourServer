using Contracts.DataTransferObject;
using Domain.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartItem : Entity<CartItemValidator>
    {
        public CartItem(string itemId, string restaurantId, string dishId, Dto.DtoDish dish, List<string> extra,
            Dto.DtoPrice price, ushort quantity, string note, bool checkOut) 
        {
            Id = itemId;
            RestaurantId = restaurantId;
            DishId = dishId;
            Dish = dish;
            Extra = extra;
            Price = price;
            Quantity = quantity;
            Note = note;
            CheckOut = checkOut;
        }
        public string RestaurantId { get; }
        public string DishId { get; }
        public Dto.DtoDish Dish { get; }
        public List<string> Extra { get; }
        public Dto.DtoPrice Price { get; }
        public ushort Quantity { get; private set; }
        public string Note { get; }
        public bool CheckOut { get; private set; }

        public void SetQuantity(ushort quantity)
            => Quantity = quantity;

        public void Delete()
            => IsDeleted = true;

        public void SetCheckOut(bool checkOut)
            => CheckOut = checkOut;

        public static implicit operator CartItem(Dto.CartItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Dish, item.Extra, item.Price, item.Quantity, item.Note, item.CheckOut);

        public static implicit operator Dto.CartItem(CartItem item)
            => new(item.Id, item.RestaurantId, item.DishId, item.Dish, item.Extra, item.Price, item.Quantity, item.Note, item.CheckOut);
    }
}
