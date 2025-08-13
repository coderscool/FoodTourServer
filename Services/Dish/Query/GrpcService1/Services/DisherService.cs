using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Dish;
using Contracts.Services.Dish.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class DisherService : Disher.DisherBase
    {
        private readonly ILogger<DisherService> _logger;
        private readonly IInteractor<Query.DishDetailsById, Projection.Dishs> _interactor;
        private readonly IFindInteractor<Query.DishRestaurantQuery, Projection.Dishs> _dishRestaurantInteractor;
        private readonly IPagedInteractor<Query.SearchListDish, Projection.Dishs> _pagedSearchInteractor;
        private readonly IFindInteractor<Query.ListDishTredingQuery, Projection.Dishs> _findDishInteractor;
        public DisherService(ILogger<DisherService> logger,
            IInteractor<Query.DishDetailsById, Projection.Dishs> interactor,
            IFindInteractor<Query.DishRestaurantQuery, Projection.Dishs> dishRestaurantInteractor,
            IPagedInteractor<Query.SearchListDish, Projection.Dishs> pagedSearchInteractor,
            IFindInteractor<Query.ListDishTredingQuery, Projection.Dishs> findDishInteractor)
        {
            _logger = logger;
            _interactor = interactor;
            _dishRestaurantInteractor = dishRestaurantInteractor;
            _pagedSearchInteractor = pagedSearchInteractor;
            _findDishInteractor = findDishInteractor;
        }

        public override async Task<GetResponse> GetDishDetailsById(DishDetailsByIdRequest request, ServerCallContext context)
        {
            var userDetails = await _interactor.InteractAsync(request, context.CancellationToken);
            return userDetails is null
                ? new() { NotFound = new() }
                : new() { Projection = Any.Pack((DishDetails)userDetails) };
        }

        public override async Task<FindResponse> GetListDishByRestaurantId(RestaurantIdRequest request, ServerCallContext context)
        {
            var findResult = await _dishRestaurantInteractor.InteractAsync(request, context.CancellationToken);
            return findResult.Any()
            ? new()
            {
                FindResult = new()
                {
                   Projections = { findResult.Select(item => Any.Pack((DishSearch)item)) },
                }
            }
            : new() { NoContent = new() };
        }

        public override async Task<ListResponse> SearchListDish(SearchDishRequest request, ServerCallContext context)
        {
            var pagedResult = await _pagedSearchInteractor.InteractAsync(request, context.CancellationToken);
            return pagedResult.Items.Any()
            ? new()
            {
                PagedResult = new()
                {
                    Projections = { pagedResult.Items.Select(item => Any.Pack((DishSearch)item)) },
                    Page = pagedResult.Page
                }
            }
            : new() { NoContent = new() };
        }

        public override async Task<FindResponse> FindDishTrending(FindDishRequest request, ServerCallContext context)
        {
            var findResult = await _findDishInteractor.InteractAsync(request, context.CancellationToken);
            return findResult.Any()
            ? new()
            {
                FindResult = new()
                {
                    Projections = { findResult.Select(item => Any.Pack((DishTrending)item)) },
                }
            }
            : new() { NoContent = new() };
        }
    }
}