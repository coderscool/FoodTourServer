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
    public class LoginUserInteractor : IInteractor<Query.Login, Projection.User>
    {
        private readonly IProjectionGateway<Projection.User> _projectionGateway;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public LoginUserInteractor(IProjectionGateway<Projection.User> projectionGateway, IJwtTokenGenerator tokenGenerator)
        {
            _projectionGateway = projectionGateway;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<Projection.User?> InteractAsync(Query.Login query, CancellationToken cancellationToken)
        {
            var userDetails = await _projectionGateway.FindAsync(user => user.UserName == query.UserName, cancellationToken);
            if(userDetails != null) 
            {
                var token = await GenerateToken(userDetails, cancellationToken);
                if (userDetails.PassWord == query.PassWord)
                {
                    var result = new Projection.User
                    {
                        Token = token,
                        Role = userDetails.Role,
                    };
                    return result;
                }
                else
                {
                    return default; 
                }
            }

            return default;
        }

        private async Task<string> GenerateToken(Projection.User userDetails, CancellationToken cancellationToken)
            => await _tokenGenerator.Generate(userDetails.Id, userDetails.Role, cancellationToken);
    }
}
