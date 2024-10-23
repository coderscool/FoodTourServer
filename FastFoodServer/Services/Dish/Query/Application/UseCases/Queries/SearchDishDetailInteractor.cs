using Application.Abstractions;
using Contracts.Services.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using Application.Abstractions.Gateways;

namespace Application.UseCases.Queries
{
    public class SearchDishDetailInteractor : IPagedInteractor<Query.SearchDishDetail, Projection.Dish>
    {
        //private readonly IElasticSearchGateway<Projection.Dish> _elasticSearchGateway;
        private readonly IProjectionGateway<Projection.Dish> _gateway;  
        private readonly IElasticClient _client;
        public SearchDishDetailInteractor( IElasticClient client, IProjectionGateway<Projection.Dish> gateway) 
        {
            //_elasticSearchGateway = elasticSearchGateway;
            _gateway = gateway;
            _client = client;
        }
        public async Task<List<Projection.Dish?>> InteractAsync(Query.SearchDishDetail query, CancellationToken cancellationToken)
        {
            var response = await _client.SearchAsync<Projection.Dish>(s => s
                .Index("dish") 
                .Query(q => q
                    .Bool(b => b
                        .Must(
                            mq => mq.Match(m => m
                                .Field(f => f.Name) 
                                .Query(query.Name)
                            ),
                            mq => mq.Match(m => m
                                .Field(f => f.Category)
                                .Query(query.Category)
                            ),
                            mq => mq.Match(m => m
                                .Field(f => f.Nation)
                                .Query(query.Nation)
                                )
                            )
                        )
                    )
                .Skip(query.Page * query.Size)
                .Size(query.Size)
                );
            foreach (var item in response.Documents.ToList())
            {
                var result = await _gateway.FindAsync(x => x.Id == item.Id, cancellationToken);
                if (result == null)
                {
                    item.Image = "123";
                }
                else
                {
                    item.Image = result.Image;
                }
            }
            return response.Documents.ToList();
        }
    }
}
