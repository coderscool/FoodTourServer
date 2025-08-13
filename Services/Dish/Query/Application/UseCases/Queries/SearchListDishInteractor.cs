using Application.Abstractions;
using Contracts.Services.Dish;
using Nest;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Paging;

namespace Application.UseCases.Queries
{
    public class SearchListDishInteractor : IPagedInteractor<Query.SearchListDish, Projection.Dishs>
    {
        private readonly IElasticSearchGateway<Projection.Dishs> _elasticSearchGateway;
        public SearchListDishInteractor(IElasticSearchGateway<Projection.Dishs> elasticSearchGateway) 
        {
            _elasticSearchGateway = elasticSearchGateway;
        }
        public async ValueTask<IPagedResult<Projection.Dishs>> InteractAsync(Query.SearchListDish query, CancellationToken cancellationToken)
        {
            var queryES = new Func<QueryContainerDescriptor<Projection.Dishs>, QueryContainer>(q =>
                q.Bool(b => b
                    .Must(
                        m => m.Match(mq => mq.Field(f => f.Dish.Name).Query(query.Keyword)),
                        m => m.Match(t => t.Field(f => f.Search.Category).Query(query.Category)),
                        m => m.Match(t => t.Field(f => f.Search.Nation).Query(query.Nation))
                    )
                )
            );
            return await _elasticSearchGateway.SearchAsync("dish", queryES, query.Paging, cancellationToken);
        }
    }
}
