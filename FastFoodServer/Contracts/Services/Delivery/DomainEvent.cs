using Amazon.Auth.AccessControlPolicy.ActionIdentifiers;
using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services.Delivery
{
    public class DomainEvent
    {
        public record DeliveryCreate(string Id, string OrderId, string RestaurantId, string CustomerId,
            Dto.DtoPerson Restaurant, Dto.DtoPerson Customer, Dto.DtoDish Dish, ushort Quantity,
            Dto.DtoPrice Price, string OrderStatus, string Status, DateTime Date, long Version) : Message, IDomainEvent;

        public record DeliveryAddShipper(string Id, string DeliveryId, Dto.DtoPerson Shipper, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryRequireDish(string ItemId, string OrderId, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryReceiveDish(string ItemId, string OrderId, bool Confirm, string Status, long Version) : Message, IDomainEvent;


        public record DeliveryUpdateOrder(string ItemId, string Status, long Version) : Message, IDomainEvent;

        public record DeliveryConfirm(string ItemId, bool Confirm, string Status, long Version) : Message, IDomainEvent;
    }
}
