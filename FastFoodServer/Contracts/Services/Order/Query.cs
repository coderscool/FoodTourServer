using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.DataTransferObject;
using Contracts.Services.Order.Protobuf;

namespace Contracts.Services.Order
{
    public static class Query
    {
        public record GetOrderUserQuery(string Id, Paging Paging) : IQuery
        {
            public static implicit operator GetOrderUserQuery(OrderRequest request)
                => new(request.Id, request.Paging);
        }

        public record GetOrderSellerQuery(string Id, Paging Paging) : IQuery
        {
            public static implicit operator GetOrderSellerQuery(OrderRequest request)
                => new(request.Id, request.Paging);
        }
    }
}
