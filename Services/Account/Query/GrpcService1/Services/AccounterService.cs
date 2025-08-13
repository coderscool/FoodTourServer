using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Account;
using Contracts.Services.Account.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class AccounterService : Accounter.AccounterBase
    {
        private readonly IFindInteractor<Query.PositionStore, Projection.AccountSeller> _findPositionInteractor;
        private readonly IPagedInteractor<Query.SearchQuery, Projection.AccountSellerES> _pagedInteractor;
        private readonly IInteractor<Query.GetAccountId, Projection.AccountSeller> _getAccountSellerInteractor;
        private readonly IInteractor<Query.GetAccountId, Projection.AccountUser> _getAccountUserInteractor;
        private readonly IInteractor<Query.GetAccountId, Projection.AccountShipper> _getAccountShipperInteractor;

        public AccounterService(IFindInteractor<Query.PositionStore, Projection.AccountSeller> findPositionInteractor,
            IPagedInteractor<Query.SearchQuery, Projection.AccountSellerES> pagedInteractor,
            IInteractor<Query.GetAccountId, Projection.AccountSeller> getAccountSellerInteractor,
            IInteractor<Query.GetAccountId, Projection.AccountUser> getAccountUserInteractor,
            IInteractor<Query.GetAccountId, Projection.AccountShipper> getAccountShipperInteractor
            )
        {
            _findPositionInteractor = findPositionInteractor;
            _pagedInteractor = pagedInteractor;
            _getAccountSellerInteractor = getAccountSellerInteractor;
            _getAccountUserInteractor = getAccountUserInteractor;
            _getAccountShipperInteractor = getAccountShipperInteractor;
        }
        public override async Task<GetResponse> GetAccountSeller(AccountIdRequest request, ServerCallContext context)
        {
            var account = await _getAccountSellerInteractor.InteractAsync(new Query.GetAccountId(request.Id), context.CancellationToken);
            return account is null
            ? new() { NotFound = new() }
            : new() { Projection = Any.Pack((AccountSellerDetail)account) };
        }

        public override async Task<GetResponse> GetAccountUser(AccountIdRequest request, ServerCallContext context)
        {
            var account = await _getAccountUserInteractor.InteractAsync(new Query.GetAccountId(request.Id), context.CancellationToken);
            return account is null
            ? new() { NotFound = new() }
            : new() { Projection = Any.Pack((AccountUserDetail)account) };
        }

        public override async Task<GetResponse> GetAccountShipper(AccountIdRequest request, ServerCallContext context)
        {
            var account = await _getAccountShipperInteractor.InteractAsync(new Query.GetAccountId(request.Id), context.CancellationToken);
            return account is null
            ? new() { NotFound = new() }
            : new() { Projection = Any.Pack((AccountShipperDetail)account) };
        }

        public override async Task<FindResponse> GetListStoreNear(LocationRequest request, ServerCallContext context)
        {
            var findResult = await _findPositionInteractor.InteractAsync(request, context.CancellationToken);
            return findResult.Any()
            ? new()
            {
                FindResult = new()
                {
                    Projections = { findResult.Select(item => Any.Pack((AccountSellerDetail)item)) },
                }
            }
            : new() { NoContent = new() };
        }

        public override async Task<ListResponse> SearchListStore(SearchRequest request, ServerCallContext context)
        {
            var pagedResult = await _pagedInteractor.InteractAsync(request, context.CancellationToken);
            return pagedResult.Items.Any()
            ? new()
            {
                PagedResult = new()
                {
                    Projections = { pagedResult.Items.Select(item => Any.Pack((AccountSellerESDetail)item)) },
                    Page = pagedResult.Page
                }
            }
            : new() { NoContent = new() };
        }
    }
}