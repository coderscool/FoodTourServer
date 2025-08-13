using Contracts.Services.Order.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Order.Validators;

namespace WebApplication1.APIs.Order
{
    public class Queries
    {
        public record GetListOrderSeller(Orderer.OrdererClient Client, string Id, int Limit, int Offset, CancellationToken CancellationToken)
            : Validatable<GetListOrderSellerValidator>, IQuery<Orderer.OrdererClient>
        {
            public static implicit operator OrderRequest(GetListOrderSeller request)
                => new()
                {
                    Id = request.Id,
                    Paging = new() { Limit = request.Limit, Offset = request.Offset }
                };
        }

        public record GetListOrderUser(Orderer.OrdererClient Client, string Id, int Limit, int Offset, CancellationToken CancellationToken)
            : Validatable<GetListOrderUserValidator>, IQuery<Orderer.OrdererClient>
        {
            public static implicit operator OrderRequest(GetListOrderUser request)
                => new()
                {
                    Id = request.Id,
                    Paging = new() { Limit = request.Limit, Offset = request.Offset }
                };
        }

        public record GetOrderById(Orderer.OrdererClient Client, string Id, CancellationToken CancellationToken)
            : Validatable<GetOrderByIdValidator>, IQuery<Orderer.OrdererClient>
        {
            public static implicit operator GetByIdRequest(GetOrderById request)
                => new() { Id = request.Id };
        }
    }
}
