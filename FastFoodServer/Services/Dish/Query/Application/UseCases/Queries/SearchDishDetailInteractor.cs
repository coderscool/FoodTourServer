using Application.Abstractions;
using Contracts.Services.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;

namespace Application.UseCases.Queries
{
    public class SearchDishDetailInteractor : IInteractor<Query.SearchDishDetail, Projection.Dish>
    {
        private readonly IElasticSearchGateway<Projection.Dish> _elasticSearchGateway;
        private readonly ElasticClient _client;
        public SearchDishDetailInteractor(IElasticSearchGateway<Projection.Dish> elasticSearchGateway) 
        {
            _elasticSearchGateway = elasticSearchGateway;
            var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
                .DefaultIndex("your_index_name");

            _client = new ElasticClient(settings);
        }
        public async Task<Projection.Dish?> InteractAsync(Query.SearchDishDetail query, CancellationToken cancellationToken)
        {
            var searchResponse = await _elasticSearchGateway.FindAsync(q => q.Bool(b => b
                            .Must(m => m
                                .Match(mq => mq
                                    .Field(f => f.Name)
                                    .Query(query.Name)
                                ),
                                m => m
                                .Match(mq => mq
                                    .Field(f => f.Category)
                                    .Query("lẩu")
                                ),
                                m => m
                                .Range(r => r
                                    .Field(f => f.Cost)
                                    .GreaterThanOrEquals(20000)
                                    .LessThanOrEquals(50000)
                                )
                            )
                        ), cancellationToken);
            return null;
        }
    }
}
