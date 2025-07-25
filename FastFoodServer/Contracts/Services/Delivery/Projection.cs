using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Delivery
{
    public static class Projection
    {
        public record Delivery(string Id, string OrderId, string RestaurantId, string CustomerId, string ShipperId, Dto.DtoPerson Restaurant, 
            Dto.DtoPerson Customer, Dto.DtoPerson Shipper, List<Dto.OrderItem> Items, bool CompletePrepared, string Status, DateTime Date, long Version) : IProjection;
        
    }
}
