using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Delivery
{
    public static class Projection
    {
        public record Delivery(string Id, string OrderId, string RestaurantId, string CustomerId, string ShipperId,
            Dto.DtoPerson Restaurant, Dto.DtoPerson Customer, Dto.DtoDish Dish, Dto.DtoPerson Shipper, ushort Quantity,
            Dto.DtoPrice Price, string OrderStatus, string Status, DateTime Date, long Version) : IProjection;
        
    }
}
