using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.ShoppingCart
{
    public static class SummaryEvent
    {
        public record CartSubmitted(Dto.DtoShoppingCart Cart, Dto.DtoPerson Customer, ulong Total, string PaymentMethod, long Version) : Message, ISummaryEvent;
    }
}
