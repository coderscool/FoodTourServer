﻿using Contracts.DataTransferObject;
using Domain.Abstractions.Entities;
using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderItem : Entity<OrderItemValidator>
    {
        public OrderItem(string itemId, string restaurantId, string dishId, Dto.DtoPerson restaurant,
            Dto.DtoDish dish, ushort quantity, string note, Dto.DtoPrice price, string status) 
        {
            Id = itemId;
            RestaurantId = restaurantId;
            DishId = dishId;
            Restaurant = restaurant;
            Dish = dish;
            Quantity = quantity;
            Note = note;
            Price = price;
            Status = status;
        }
        public string RestaurantId { get; }
        public string DishId { get; }
        public Dto.DtoPerson Restaurant { get; }
        public Dto.DtoDish Dish { get; }
        public ushort Quantity { get; }
        public string Note { get; private set; }
        public Dto.DtoPrice Price { get; }
        public OrderItemStatus Status { get; private set; }

        public void UpdateStatus(string status)
        {
            Status = status;
        }

        public void UpdateStatus(string status, string note)
        {
            Status = status;
            Note = note;
        }

        public static implicit operator OrderItem(Dto.OrderItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Quantity, item.Note, item.Price, item.Status);

        public static implicit operator Dto.OrderItem(OrderItem item)
            => new(item.Id, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Quantity, item.Note, item.Price, item.Status);
    }
}
