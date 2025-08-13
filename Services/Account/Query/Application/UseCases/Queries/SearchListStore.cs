using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;
using Contracts.Services.Account;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var queryES = new Func<QueryContainerDescriptor<Projection.AccountSellerES>, QueryContainer>(q =>
                q.Bool(b => b
                    .Must(
                        m => m.Match(mq => mq.Field(f => f.Name).Query(query.Keyword)),
                        m => m.Match(t => t.Field(f => f.Nation).Query(query.Nation)),
                        m => m.Match(t => t.Field(f => f.Address).Query(query.City))
                    )
                )
            );
            return await _elasticSearchGateway.SearchAsync("account", queryES, query.Paging, cancellationToken);
        }
    }
}
