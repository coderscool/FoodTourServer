using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;
using Contracts.Services.Account;

namespace Application.UseCases.Queries
{
    public class SearchListStore : IPagedInteractor<Query.SearchQuery, Projection.AccountSellerES>
    {
        private readonly IElasticSearchGateway<Projection.AccountSellerES> _elasticSearchGateway;
        public SearchListStore(IElasticSearchGateway<Projection.AccountSellerES> elasticSearchGateway)
        {
            _elasticSearchGateway = elasticSearchGateway;
        }
        public async ValueTask<IPagedResult<Projection.AccountSellerES>> InteractAsync(Query.SearchQuery query, CancellationToken cancellationToken)
        {
            return await _elasticSearchGateway.SearchAsync(
        string.IsNullOrWhiteSpace(query.Keyword) ? "*" : query.Keyword,
        options =>
        {
            options.Size = 1000;
            options.Skip = 0;

            var filters = new List<string>();
            if (!string.IsNullOrWhiteSpace(query.Nation))
                filters.Add($"Nation eq '{query.Nation}'");
            if (!string.IsNullOrWhiteSpace(query.City))
                filters.Add($"Address eq '{query.City}'");

            if (filters.Count > 0)
                options.Filter = string.Join(" and ", filters);

            return options;
        },
        query.Paging,
        cancellationToken);
        }
    }
}
