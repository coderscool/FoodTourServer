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
        public CartItem(string id, string userId, Dto.DtoPerson restaurant, Dto.DtoDish dish, Dto.DtoPrice price, int quantity) 
        {
            Id = id;
            UserId = userId;
            Restaurant = restaurant;
            Dish = dish;
            Price = price;
            Quantity = quantity;
        }
        public string Id { get;}
        public string UserId { get; }
        public Dto.DtoPerson Restaurant { get; }
        public Dto.DtoDish Dish { get; }
        public Dto.DtoPrice Price { get; }
        public int Quantity { get; private set; }

        public void Increase(int quantity)
        => Quantity += quantity;

        public void Decrease(int quantity)
            => Quantity += quantity;

        public static implicit operator CartItem(Dto.CartItem item)
        => new(item.Id, item.Product, item.Quantity, item.UnitPrice);

        public static implicit operator Dto.CartItem(CartItem item)
            => new(item.Id, item.Product, item.Quantity, item.UnitPrice);
    }
}
