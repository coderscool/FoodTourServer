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
    }
}
