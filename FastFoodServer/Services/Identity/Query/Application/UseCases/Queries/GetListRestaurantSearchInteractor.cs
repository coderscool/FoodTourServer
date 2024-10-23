using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Identity;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetListRestaurantSearchInteractor : IPagedInteractor<Query.GetRestaurantRequest, Projection.User>
    {
        private readonly IProjectionGateway<Projection.User> _projectionGateway;
        private readonly IElasticClient _elasticClient;
        public GetListRestaurantSearchInteractor(IProjectionGateway<Projection.User> projectionGateway, IElasticClient elasticClient) 
        {
            _projectionGateway = projectionGateway;
            _elasticClient = elasticClient;
        }
        public async Task<List<Projection.User>> InteractAsync(Query.GetRestaurantRequest query, CancellationToken cancellationToken)
        {
            var response = await _elasticClient.SearchAsync<Projection.User>(s => s
                .Index("user")
                .Query(q => q
                    .Bool(b => b
                        .Must(
                            mq => mq.Match(m => m
                                .Field(f => f.Name)
                                .Query(query.Key)
                                ),
                            mq => mq.Match(m => m
                                .Field(f => f.Nation)
                                .Query(query.Nation)
                                ),
                             mq => mq.Match(m => m
                                .Field(f => f.Address)
                                .Query(query.Location)
                                ),
                             mq => mq.Match(m => m
                                .Field(f => f.Role)
                                .Query("sale")
                                )
                            )
                        )
                    )
                .Skip(query.Page * query.Size)
                .Size(query.Size)
                );
            foreach ( var item in response.Documents.ToList())
            {
                var result = await _projectionGateway.FindAsync(x => x.Id == item.Id, cancellationToken);
                if(result == null)
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
