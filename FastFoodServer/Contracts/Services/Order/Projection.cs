using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Order.Protobuf;
using static Contracts.DataTransferObject.Dto;

namespace Contracts.Services.Order
{
    public static class Projection
    {
        public record Order(string Id, string CustomerId, DtoPerson Customer, ulong Total, long Version) : IProjection
        {
            public static implicit operator OrderDetails(Order order)
                => new()
                {
                    Id = order.Id,
                    Total = order.Total,
                };
        }

        public record OrderGroup(string Id, string OrderId, string RestaurantId, string CustomerId, 
            DtoPerson Restaurant, DtoPerson Customer, List<OrderItem> Items,
            string Status, DateTime Date, long Version) : IProjection
        {
            public static implicit operator OrderGroupDetail(OrderGroup order)
                => new()
                {
                    GroupId = order.Id,
                    OrderId = order.OrderId,
                    Items = { order.Items.Select(item => (OrderItemDetail)item) },
                };
        }
    }
}
