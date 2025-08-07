using Contracts.Abstractions.Messages;

namespace Contracts.Services.Payment
{
    public static class Projection 
    {
        public record Payment(string Id, string OrderId, ulong Total, string PaymentMenthod, string? TransactionId, string PaymentStatus, bool SellerConfirm, DateTime PaidAt, long Version) : IProjection;
    }
}
