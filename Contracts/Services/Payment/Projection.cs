using Contracts.Abstractions.Messages;
using Contracts.Services.Payment.Protobuf;
using Google.Protobuf.WellKnownTypes;

namespace Contracts.Services.Payment
{
    public static class Projection
    {
        public record Payment(string Id, string OrderId, ulong Total, string PaymentMenthod, string? TransactionId, string PaymentStatus, bool SellerConfirm, DateTime PaidAt, long Version) : IProjection
        {   
            public static implicit operator PaymentDetails(Payment payment)
                => new()
                {
                    Id = payment.Id,
                    OrderId = payment.OrderId,
                    Total = payment.Total,
                    PaymentMenthod = payment.PaymentMenthod,
                    TransactionId = payment.TransactionId,
                    PaymentStatus = payment.PaymentStatus,
                    SellerConfirm = payment.SellerConfirm,
                    PaidAt = Timestamp.FromDateTime(payment.PaidAt)
                };
        }
    }
}
