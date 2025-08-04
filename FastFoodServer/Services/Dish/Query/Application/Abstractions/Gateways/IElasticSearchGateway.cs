using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Nest;

namespace Application.Abstractions.Gateways
{
    public interface IElasticSearchGateway<TProjection> where TProjection : class, IProjection
    {
        ValueTask<IPagedResult<TProjection>> SearchAsync(
            string indexName,
            Func<QueryContainerDescriptor<TProjection>, QueryContainer> query,
            Paging Paging,
            CancellationToken cancellationToken
        );

        Task InsertDocumentAsync(TProjection project);

        Task UpdateFieldsAsync(
            string id,
            Dictionary<string, object> updates,
            CancellationToken cancellationToken);
    }
}
