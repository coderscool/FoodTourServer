using Contracts.DataTransferObject;

namespace WebApplication1.APIs.Order
{
    public class Payloads
    {
        public record ConfirmOrderPayload(string ItemId, Dto.DtoPerson Restaurant, bool Confirm);
    }
}
