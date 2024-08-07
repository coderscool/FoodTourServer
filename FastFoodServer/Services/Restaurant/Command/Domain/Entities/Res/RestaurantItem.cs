﻿using Contracts.Abstractions.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Res
{
    public class RestaurantItem
    {
        public RestaurantItem(string id, string orderId, string restaurantId, string customerId, string dishId,
            Dto.Person customer, string name, long price, int quantity, int time, bool status, DateTime date)
        {
            Id = id;
            OrderId = orderId;
            RestaurantId = restaurantId;
            CustomerId = customerId;
            DishId = dishId;
            Customer = new PersonDetail(customer.Name, customer.Phone, customer.Address);
            Name = name;
            Price = price;
            Quantity = quantity;
            Time = time;
            Status = status;
            Date = date;
        }
        public string Id { get; }
        public string OrderId { get; }
        public string RestaurantId { get; }
        public string CustomerId { get; }
        public string DishId { get; }
        public PersonDetail Customer { get; }
        public string Name { get; }
        public long Price { get; }
        public int Quantity { get; }
        public int Time { get; }
        public bool Status { get; private set; }
        public DateTime Date { get; }

        public void UpdateStatus(bool  status)
            => Status = status;
    }
}
