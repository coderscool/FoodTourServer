﻿using Contracts.DataTransferObject;
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
        public CartItem(string itemId, string restaurantId, string dishId, Dto.DtoPerson restaurant, Dto.DtoDish dish, Dto.DtoPrice price, ushort quantity, string note) 
        {
            Id = itemId;
            RestaurantId = restaurantId;
            DishId = dishId;
            Restaurant = restaurant;
            Dish = dish;
            Price = price;
            Quantity = quantity;
            Note = note;
        }
        public string RestaurantId { get; }
        public string DishId { get; }
        public Dto.DtoPerson Restaurant { get; }
        public Dto.DtoDish Dish { get; }
        public Dto.DtoPrice Price { get; }
        public ushort Quantity { get; private set; }
        public string Note { get; }

        public void Increase(ushort quantity)
        => Quantity += quantity;

        public void Decrease(ushort quantity)
            => Quantity -= quantity;

        public void SetQuantity(ushort quantity)
            => Quantity = quantity;

        public void Delete()
            => IsDeleted = true;

        public static implicit operator CartItem(Dto.CartItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Price, item.Quantity, item.Note);

        public static implicit operator Dto.CartItem(CartItem item)
            => new(item.Id, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Price, item.Quantity, item.Note);
    }
}
