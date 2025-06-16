using Contracts.Abstractions.Messages;

namespace Contracts.Services.Payment
{
    public static class DomainEvent
    {
        public record PaymentRequest(string Id, string OrderId, ulong Total, string PaymentMenthod, string? TransactionId, string PaymentStatus, bool PaymentConfirm, DateTime PaidAt, long Version) : Message, IDomainEvent;
        public record PaymentCreate(string Id, ulong Budget, long Version) : Message, IDomainEvent;
    }
}
