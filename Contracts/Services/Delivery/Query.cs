using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.Services.Delivery.Protobuf;

namespace Contracts.Services.Delivery
{
    public static class Query 
    {
        public record GetById(string Id) : IQuery
        {
            public static implicit operator GetById(GetByIdRequest request)
                => new( request.Id );
        }

        public record GetList(Paging Paging) : IQuery
        {
            public static implicit operator GetList(GetListRequest request)
                => new(request.Paging);
        }
    }
}
