using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Delivery;
using Contracts.Services.Delivery.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class DeliveryService : Deliverier.DeliverierBase
    {
        private readonly ILogger<DeliveryService> _logger;
        private readonly IInteractor<Query.GetById, Projection.Delivery> _interactor;
        private readonly IPagedInteractor<Query.GetList, Projection.Delivery> _pagedInteractor;
        public DeliveryService(ILogger<DeliveryService> logger,
            IInteractor<Query.GetById, Projection.Delivery> interactor,
            IPagedInteractor<Query.GetList, Projection.Delivery> pagedInteractor)
        {
            _logger = logger;
            _interactor = interactor;
            _pagedInteractor = pagedInteractor;
        }

        public override async Task<GetResponse> GetDeliveryDetail(GetByIdRequest request, ServerCallContext context)
        {
            var delivery = await _interactor.InteractAsync(request, context.CancellationToken);
            return delivery is null
                ? new GetResponse { NotFound = new() }
                : new GetResponse { Projection = Any.Pack((DeliveryDetail)delivery) };
        }

        public override async Task<ListResponse> GetListDelivery(GetListRequest request, ServerCallContext context)
        {
            var pagedResult = await _pagedInteractor.InteractAsync(request, context.CancellationToken);
            return pagedResult.Items.Any()
                ? new ListResponse
                {
                    PagedResult = new()
                    {
                        Projections = { pagedResult.Items.Select(item => Any.Pack((DeliveryDetail)item)) },
                        Page = pagedResult.Page,
                    }
                }
                : new ListResponse { NoContent = new() };
        }
    }
}