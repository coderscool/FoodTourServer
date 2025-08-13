using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Protobuf;
using Contracts.DataTransferObject;
using Contracts.Services.Delivery.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Contracts.Services.Delivery
{
    public static class Projection
    {
        public record Delivery(string Id, string OrderId, string RestaurantId, string CustomerId, string ShipperId, Dto.DtoPerson Restaurant,
            Dto.DtoPerson Customer, Dto.DtoPerson Shipper, List<Dto.OrderItem> Items, bool CompletePrepared, string Status, DateTime Date, long Version) : IProjection
        {
            public static implicit operator DeliveryDetail(Delivery delivery)
                => new()
                { 
                    Id = delivery.Id, 
                    OrderId = delivery.OrderId, 
                    RestaurantId = delivery.RestaurantId, 
                    CustomerId = delivery.CustomerId, 
                    ShipperId = delivery.ShipperId,
                    Restaurant = delivery.Restaurant, 
                    Customer = delivery.Customer,
                    Items = { delivery.Items.Select(item => (OrderItemDetail)item) },
                    CompletePrepared = delivery.CompletePrepared, 
                    Status = delivery.Status,
                    PaidAt = Timestamp.FromDateTime(delivery.Date)
                };
        }
    }
}
