using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Order;
using Contracts.Services.Order.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class OrdererService : Orderer.OrdererBase
    {
        private readonly ILogger<OrdererService> _logger;
        private readonly IInteractor<Query.GetOrderByIdQuery, Projection.OrderGroup> _interactor;
        private readonly IPagedInteractor<Query.GetOrderSellerQuery, Projection.OrderGroup> _getListOrderSeller;
        private readonly IPagedInteractor<Query.GetOrderUserQuery, Projection.OrderGroup> _getListOrderUser;

        public OrdererService(ILogger<OrdererService> logger,
            IInteractor<Query.GetOrderByIdQuery, Projection.OrderGroup> interactor,
            IPagedInteractor<Query.GetOrderSellerQuery, Projection.OrderGroup> getListOrderSeller,
            IPagedInteractor<Query.GetOrderUserQuery, Projection.OrderGroup> getListOrderUser)
        {
            _logger = logger;
            _interactor = interactor;
            _getListOrderSeller = getListOrderSeller;
            _getListOrderUser = getListOrderUser;
        }

        public override async Task<GetResponse> GetOrderDetail(GetByIdRequest request, ServerCallContext context)
        {
            var order = await _interactor.InteractAsync(request, context.CancellationToken);
            return order is null
                ? new GetResponse { NotFound = new() }
                : new GetResponse { Projection = Any.Pack((OrderDetails)order) };
        }

        public override async Task<ListResponse> GetListOrderSeller(OrderRequest request, ServerCallContext context)
        {
            var pagedResult = await _getListOrderSeller.InteractAsync(request, context.CancellationToken);
            return pagedResult.Items.Any()
            ? new()
            {
                PagedResult = new()
                {
                    Projections = { pagedResult.Items.Select(item => Any.Pack((OrderSeller)item)) },
                    Page = pagedResult.Page
                }
            }
            : new() { NoContent = new() };
        }

        public override async Task<ListResponse> GetListOrderUser(OrderRequest request, ServerCallContext context)
        {
            var pagedResult = await _getListOrderUser.InteractAsync(request, context.CancellationToken);
            return pagedResult.Items.Any()
            ? new()
            {
                PagedResult = new()
                {
                    Projections = { pagedResult.Items.Select(item => Any.Pack((OrderUser)item)) },
                    Page = pagedResult.Page
                }
            }
            : new() { NoContent = new() };
        }
    }
}