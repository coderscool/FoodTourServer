using Contracts.Abstractions.Messages;
using Contracts.Services.Order.Protobuf;
using static Contracts.DataTransferObject.Dto;

namespace Contracts.Services.Order
{
    public static class Projection
    {
        public record Order(string Id, string CustomerId, DtoPerson Customer, ulong Total, string Description, string Status, long Version) : IProjection
        {
            public static implicit operator OrderDetails(Order order)
                => new()
                {
                    Id = order.Id,
                    Total = order.Total,
                    Description = order.Description,
                    Status = order.Status
                };
        }

        public record OrderItem(string Id, string OrderId, string RestaurantId, string CustomerId, string DishId, 
            DtoPerson Restaurant, DtoPerson Customer, DtoDish Dish, ushort Quantity, DtoPrice Price, string Note,
            string Status, DateTime Date, long Version) : IProjection
        {
            public static implicit operator OrderItems(OrderItem order)
                => new()
                {
                    Id = order.Id,
                    OrderId = order.OrderId,
                    DishId = order.DishId,
                    RestaurantName = order.Restaurant.Name,
                    DishName = order.Dish.Name,
                    Price = order.Price,
                    Quantity = order.Quantity,
                    Note = order.Note,
                    Status = order.Status
                };
        }
    }
}
