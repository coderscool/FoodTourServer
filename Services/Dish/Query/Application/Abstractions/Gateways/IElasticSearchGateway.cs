using Azure.Search.Documents;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;

namespace Application.Abstractions.Gateways
{
    public interface IElasticSearchGateway<TProjection> where TProjection : class, IProjection
    {
        ValueTask<IPagedResult<TProjection>> SearchAsync(
            string searchText,
            Func<SearchOptions, SearchOptions> configureOptions,
            Paging paging,
            CancellationToken cancellationToken);

        Task InsertDocumentAsync(TProjection project);
    }
}
