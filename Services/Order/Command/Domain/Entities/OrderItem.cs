using Contracts.DataTransferObject;
using Domain.Abstractions.Entities;
using Domain.Entities.Validators;
using Domain.Enumerations;

namespace Domain.Entities
{
    public class OrderItem : Entity<OrderItemValidator>
    {
        public OrderItem(string itemId, string dishId, Dto.DtoDish dish, List<string> extra, ushort quantity, string note, Dto.DtoPrice price) 
        {
            Id = itemId;
            DishId = dishId;
            Dish = dish;
            Extra = extra;
            Quantity = quantity;
            Note = note;
            Price = price;
        }
        public string DishId { get; }
        public Dto.DtoDish Dish { get; }
        public List<string> Extra { get; } 
        public ushort Quantity { get; }
        public string Note { get; private set; }
        public Dto.DtoPrice Price { get; }

        public static implicit operator OrderItem(Dto.OrderItem item)
            => new(item.ItemId, item.DishId, item.Dish, item.Extra, item.Quantity, item.Note, item.Price);

        public static implicit operator Dto.OrderItem(OrderItem item)
            => new(item.Id, item.DishId, item.Dish, item.Extra, item.Quantity, item.Note, item.Price);
    }
}
