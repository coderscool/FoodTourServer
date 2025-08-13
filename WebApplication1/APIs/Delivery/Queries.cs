using Contracts.Services.Delivery.Protobuf;
using WebApplication1.Abstractions;
using WebApplication1.APIs.Delivery.Validators;

namespace WebApplication1.APIs.Delivery
{
    public static class Queries 
    {
        public record GetListDelivery(Deliverier.DeliverierClient Client, int Limit, int Offset, CancellationToken CancellationToken)
            : Validatable<GetListDeliveryValidator>, IQuery<Deliverier.DeliverierClient>
        {
            public static implicit operator GetListRequest(GetListDelivery request)
                => new() 
                { 
                    Paging = new() { Limit = request.Limit, Offset = request.Offset } 
                };
        }

        public record GetDeliveryById(Deliverier.DeliverierClient Client, string Id, CancellationToken CancellationToken)
            : Validatable<GetDeliveryByIdValidator>, IQuery<Deliverier.DeliverierClient>
        {
            public static implicit operator GetByIdRequest(GetDeliveryById request)
                => new() { Id = request.Id };
        }
    }
}
