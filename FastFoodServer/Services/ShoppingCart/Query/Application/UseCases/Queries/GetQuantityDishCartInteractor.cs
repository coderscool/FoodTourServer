using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Abstractions.Messages;
using Contracts.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetQuantityDishCartInteractor : ICountInteractor<Query.CustomerCartQuery>
    {
        private readonly IProjectionGateway<Projection.Cart> _projectionGateway;
        public GetQuantityDishCartInteractor(IProjectionGateway<Projection.Cart> projectionGateway) 
        { 
            _projectionGateway = projectionGateway;
        }
        public async Task<int> InteractAsync(Query.CustomerCartQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.QuantityAsync(x => x.CustomerId == query.CustomerId, cancellationToken);
    }
}
