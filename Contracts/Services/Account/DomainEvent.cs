using Contracts.DataTransferObject;
using Contracts.Abstractions.Messages;

namespace Contracts.Services.Account
{
    public static class DomainEvent
    {
        public record AccountUserCreate(string Id, string Name, string Image, long Version) : Message, IDomainEvent;
        public record AccountSellerCreate(string Id, Dto.DtoPerson Seller, string Image, string Nation, Dto.TimeActive TimeActive, bool Status, long Version) : Message, IDomainEvent;
        public record AccountShipperCreate(string Id, Dto.DtoPerson Shipper, string Image, bool isTransport, bool Status, long Version) : Message, IDomainEvent;

    }
}
