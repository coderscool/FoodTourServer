using Contracts.Abstractions.Messages;

namespace Contracts.Services.Payment
{
    public static class DomainEvent
    {
        public record PaymentRequest(string Id, string RestauranId, string OrderId, ulong Total, string PaymentMenthod, string? TransactionId, string PaymentStatus, bool SellerConfirm, DateTime PaidAt, long Version) : Message, IDomainEvent;
        public record PaymentComplete(string Id, string Status, long Version) : Message, IDomainEvent;
        public record PaymentSellerConnfirm(string Id, string RestaurantId, ulong Total, bool Confirm, long Version) : Message, IDomainEvent;
    }
}
