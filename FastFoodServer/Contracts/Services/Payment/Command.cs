using Contracts.Abstractions.Messages;
using Contracts.DataTransferObject;

namespace Contracts.Services.Payment
{
    public static class Command
    {
        public record RequestPayment(Dto.OrderGroup Group, string PaymentMethod) : Message, ICommand;
        public record CompletePayment(string ItemId) : Message, ICommand;
        public record SellerConfirmPayment(string ItemId) : Message, ICommand;
    }
}
