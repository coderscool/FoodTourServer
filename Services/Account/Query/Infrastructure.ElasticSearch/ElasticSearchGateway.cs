using Application.Abstractions.Gateways;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Infrastructure.ElasticSearch.Pagination;


namespace Infrastructure.ElasticSearch
{
    public class AzureSearchGateway<TProjection> : IElasticSearchGateway<TProjection>
        where TProjection : class, IProjection
    {
        private readonly SearchClient _client;

        public AzureSearchGateway(SearchClient client)
        {
            _client = client;
        }

        public async Task InsertDocumentAsync(TProjection projection)
        {
            try
            {
                var response = await _client.IndexDocumentsAsync(
                    IndexDocumentsBatch.Create(
                        IndexDocumentsAction.Upload(projection)
                    )
                );

                if (response.Value.Results.All(r => r.Succeeded))
                {
                    Console.WriteLine("Đã thêm dữ liệu thành công vào Azure Search.");
                }
                else
                {
                    foreach (var result in response.Value.Results.Where(r => !r.Succeeded))
                    {
                        Console.WriteLine($"Lỗi khi insert: {result.ErrorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public async ValueTask<IPagedResult<TProjection>> SearchAsync(
            string searchText,
            Func<SearchOptions, SearchOptions> configureOptions,
            Paging paging,
            CancellationToken cancellationToken)
        {
            var options = configureOptions(new SearchOptions());

            var response = await _client.SearchAsync<TProjection>(
                searchText,
                options,
                cancellationToken);

            var docs = response.Value.GetResults().Select(r => r.Document).ToList();

            return await PagedResult<TProjection>.CreateAsync(paging, docs, cancellationToken);
        }
    }

}
