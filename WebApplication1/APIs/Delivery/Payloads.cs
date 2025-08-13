using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Delivery
{
    public static class Payloads
    {
        public record ShipperDeliveryPayload(string Id, Dto.DtoPerson Shipper);
    }
}
