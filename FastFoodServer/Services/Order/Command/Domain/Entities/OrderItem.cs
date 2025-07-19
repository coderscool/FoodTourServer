using Contracts.DataTransferObject;
using Domain.Abstractions.Entities;
using Domain.Enumerations;

namespace Domain.Entities
{
    public class OrderItem : Entity<OrderItemValidator>
    {
        public OrderItem(string itemId, string restaurantId, string dishId, Dto.DtoPerson restaurant, Dto.DtoDish dish, 
            List<string> extra, ushort quantity, string note, Dto.DtoPrice price, string status) 
        {
            Id = itemId;
            RestaurantId = restaurantId;
            DishId = dishId;
            Restaurant = restaurant;
            Dish = dish;
            Extra = extra;
            Quantity = quantity;
            Note = note;
            Price = price;
            Status = status;
        }
        public string RestaurantId { get; }
        public string DishId { get; }
        public Dto.DtoPerson Restaurant { get; private set; }
        public Dto.DtoDish Dish { get; }
        public List<string> Extra { get; } 
        public ushort Quantity { get; }
        public string Note { get; private set; }
        public Dto.DtoPrice Price { get; }
        public OrderItemStatus Status { get; private set; }

        public void UpdateStatus(string status)
        {
            Status = status;
        }

        public void UpdateRestaurant(Dto.DtoPerson restaurant)
        {
            Restaurant = restaurant;
        }

        public static implicit operator OrderItem(Dto.OrderItem item)
            => new(item.ItemId, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Extra, item.Quantity, item.Note, item.Price, item.Status);

        public static implicit operator Dto.OrderItem(OrderItem item)
            => new(item.Id, item.RestaurantId, item.DishId, item.Restaurant, item.Dish, item.Extra, item.Quantity, item.Note, item.Price, item.Status);
    }
}
