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
        private readonly IFindInteractor<Query.PositionStore, Projection.Account> _findPositionInteractor;
        private readonly IPagedInteractor<Query.SearchQuery, Projection.AccountES> _pagedInteractor;
        public AccounterService(IFindInteractor<Query.PositionStore, Projection.Account> findPositionInteractor,
            IPagedInteractor<Query.SearchQuery, Projection.AccountES> pagedInteractor)
        {
            _findPositionInteractor = findPositionInteractor;
            _pagedInteractor = pagedInteractor;
        }
        public override async Task<FindResponse> GetListStoreNear(LocationRequest request, ServerCallContext context)
        {
            var findResult = await _findPositionInteractor.InteractAsync(request, context.CancellationToken);
            return findResult.Any()
            ? new()
            {
                FindResult = new()
                {
                    Projections = { findResult.Select(item => Any.Pack((AccountDetails)item)) },
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
                    Projections = { pagedResult.Items.Select(item => Any.Pack((AccountDetails)item)) },
                    Page = pagedResult.Page
                }
            }
            : new() { NoContent = new() };
        }
    }
}