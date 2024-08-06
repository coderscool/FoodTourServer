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
    public class GetListDishCartInteractor : IPagedInteractor<Query.CustomerCartQuery, Projection.Cart>
    {
        private readonly IProjectionGateway<Projection.Cart> _projectionGateway;
        public GetListDishCartInteractor(IProjectionGateway<Projection.Cart> projectionGateway) 
        { 
            _projectionGateway = projectionGateway;
        }
        public async Task<List<Projection.Cart?>> InteractAsync(Query.CustomerCartQuery query, CancellationToken cancellationToken)
            => await _projectionGateway.ListAsync(cart => cart.CustomerId ==  query.CustomerId, cancellationToken);
    }
}
