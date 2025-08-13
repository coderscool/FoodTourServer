using Contracts.Abstractions.Messages;
using Contracts.Services.Payment.Protobuf;

namespace Contracts.Services.Payment
{
    public static class Query 
    {
        public record GetPaymentByIdQuery(string Id) : IQuery
        {
            public static implicit operator GetPaymentByIdQuery(GetPaymentByIdRequest request)
                => new(request.Id);
        }
    }
}
