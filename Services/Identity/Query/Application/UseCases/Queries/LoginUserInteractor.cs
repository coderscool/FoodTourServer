using Application.Abstractions;
using Application.Abstractions.Gateways;
using Contracts.Services.Identity;

namespace Application.UseCases.Queries
{
    public class LoginUserInteractor : IInteractor<Query.Login, Projection.Identity>
    {
        private readonly IProjectionGateway<Projection.Identity> _projectionGateway;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginUserInteractor(IProjectionGateway<Projection.Identity> projectionGateway, IJwtTokenGenerator tokenGenerator)
        {
            _projectionGateway = projectionGateway;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<Projection.Identity?> InteractAsync(Query.Login query, CancellationToken cancellationToken)
        {
            var identity = await _projectionGateway.FindAsync(user => user.UserName == query.Username, cancellationToken);
            if(identity != null) 
            {
                var token = await GenerateToken(identity, cancellationToken);
                if (identity.PassWord == query.Password)
                {
                    return identity with { Token = token};
                }
                else
                {
                    return default; 
                }
            }

            return default;
        }

        private async Task<string> GenerateToken(Projection.Identity userDetails, CancellationToken cancellationToken)
            => await _tokenGenerator.Generate(userDetails.Id, userDetails.Role, cancellationToken);
    }
}
