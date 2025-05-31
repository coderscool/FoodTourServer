using Application.Abstractions;
using Contracts.Services.Identity;
using Contracts.Services.Identity.Protobuf;
using Contracts.Abstractions.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class IdentiterService : Identiter.IdentiterBase
    {
        private readonly ILogger<IdentiterService> _logger;
        private readonly IInteractor<Query.Login, Projection.User> _getLoginUser;
        private readonly IPagedInteractor<Query.ListRestaurantItems, Projection.User> _listRestaurants;
        public IdentiterService(ILogger<IdentiterService> logger,
            IInteractor<Query.Login, Projection.User> getLoginUser,
            IPagedInteractor<Query.ListRestaurantItems, Projection.User> listRestaurants)
        {
            _logger = logger;
            _getLoginUser = getLoginUser;
            _listRestaurants = listRestaurants;
        }

        public override async Task<GetResponse> Login(LoginRequest request, ServerCallContext context)
        {
            var userDetails = await _getLoginUser.InteractAsync(request, context.CancellationToken);
            return userDetails is null
            ? new() { NotFound = new() }
            : new() { Projection = Any.Pack((UserDetails)userDetails) };
        }

        public override async Task<ListResponse> ListRestaurantItems(ListRestaurantItemsRequest request, ServerCallContext context)
        {
            var pagedResult = await _listRestaurants.InteractAsync(request, context.CancellationToken);
            return pagedResult.Items.Any()
            ? new()
            {
                PagedResult = new()
                {
                    Projections = { pagedResult.Items.Select(item => Any.Pack((UserDetails)item)) },
                    Page = pagedResult.Page
                }
            }
            : new() { NoContent = new() };
        }
    }
}