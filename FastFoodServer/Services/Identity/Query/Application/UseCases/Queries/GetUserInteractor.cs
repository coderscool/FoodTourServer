using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetUserInteractor : IInteractor<Query.GetUserRequest, Projection.User>
    {
        private readonly IProjectionGateway<Projection.User> _projectionGateway;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public GetUserInteractor(IProjectionGateway<Projection.User> projectionGateway, IJwtTokenGenerator tokenGenerator)
        {
            _projectionGateway = projectionGateway;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<Projection.User?> InteractAsync(Query.GetUserRequest query, CancellationToken cancellationToken)
        {
            var result = await _projectionGateway.FindAsync(user => user.Id == query.Id, cancellationToken);
            return result;
        }
    }
}
