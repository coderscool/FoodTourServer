using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetListDishCartInteractor : IFindInteractor<Query.CustomerCartQuery, Projection.CartItem>
    {
        private readonly IProjectionGateway<Projection.CartItem> _projectionGateway;
        public GetListDishCartInteractor(IProjectionGateway<Projection.CartItem> projectionGateway) 
        { 
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.CartItem?>> InteractAsync(Query.CustomerCartQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.ListAsync(cart => cart.CustomerId ==  query.CustomerId, cancellationToken);
    }
}
