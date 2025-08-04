using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Infrastructure.ElasticSearch.Pagination;
using Nest;

namespace Infrastructure.ElasticSearch
{
    public class ElasticSearchGateway<TProjection> : IElasticSearchGateway<TProjection>
        where TProjection : class, IProjection
    {
        private readonly IElasticClient _client;

        public ElasticSearchGateway(IElasticClient client)
        {
            _client = client;
        }

        public async Task InsertDocumentAsync(TProjection projection)
        {
            Console.WriteLine("------------------------");
            var response = await _client.IndexDocumentAsync(projection);
            if (response.IsValid)
            {
                Console.WriteLine("Đã thêm dữ liệu thành công.");
            }
            else
            {
                Console.WriteLine($"Lỗi: {response.OriginalException.Message}");
            }
        }

        public async ValueTask<IPagedResult<TProjection>> SearchAsync(string indexName, Func<QueryContainerDescriptor<TProjection>, QueryContainer> query, 
            Paging Paging, CancellationToken cancellationToken)
        {
            var response = await _client.SearchAsync<TProjection>(s => s
                .Index(indexName)
                .Query(query)
            );
            Console.WriteLine(response.Documents.ToList().ToString());
            return await PagedResult<TProjection>.CreateAsync(Paging, response.Documents.ToList(), cancellationToken);
        }

        public async Task UpdateFieldsAsync(
    string id,
    Dictionary<string, object> updates,
    CancellationToken cancellationToken)
        {
            var scriptSource = string.Join(" ",
        updates.Select(kv => $"ctx._source.{kv.Key} = params.{kv.Key};"));

            var response = await _client.UpdateAsync<TProjection>(id, u => u
                .Index("dish")
                .Script(s => s
                    .Source(scriptSource)
                    .Params(updates)
                ),
                cancellationToken
            );

            if (!response.IsValid)
            {
                throw new Exception($"Elasticsearch update failed: {response.ServerError?.Error?.Reason}");
            }
        }

    }
}
