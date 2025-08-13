using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Cart.Protobuf;
using Contracts.Services.ShoppingCart;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class CarterService : Carter.CarterBase
    {
        private readonly IFindInteractor<Query.CustomerCartQuery, Projection.CartItem> _pagedInteractor;
        private readonly ILogger<CarterService> _logger;
        
        public CarterService(ILogger<CarterService> logger, IFindInteractor<Query.CustomerCartQuery, Projection.CartItem> pagedInteractor)
        {
            _logger = logger;
            _pagedInteractor = pagedInteractor;
        }

        public override async Task<FindResponse> GetListDishCart(GetListCartRequest request, ServerCallContext context)
        {
            var pagedResult = await _pagedInteractor.InteractAsync(request, context.CancellationToken);
            return pagedResult.Any()
                ? new()
                {
                    FindResult = new()
                    {
                        Projections = { pagedResult.Select(item => Any.Pack((CartItemDetail)item)) },
                    }
                }
                : new() { NoContent = new() };
        }
    }
}