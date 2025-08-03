using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.DataTransferObject;
using Contracts.Services.Order.Protobuf;

namespace Contracts.Services.Order
{
    public static class Query
    {
        public record GetOrderQuery(string Id, Paging Paging) : IQuery
        {
            public static implicit operator GetOrderQuery(OrderRequest request)
                => new(request.Id, request.Paging);
        }
    }
}
