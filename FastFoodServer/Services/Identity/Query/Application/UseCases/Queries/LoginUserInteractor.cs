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
    public class LoginUserInteractor : IInteractor<Query.Login, Projection.LoginUser>
    {
        private readonly IProjectionGateway<Projection.LoginUser> _projectionGateway;
        public LoginUserInteractor(IProjectionGateway<Projection.LoginUser> projectionGateway)
        {
            _projectionGateway = projectionGateway;
        }
        public async Task<Projection.LoginUser?> InteractAsync(Query.Login query, CancellationToken cancellationToken)
        {
            var userDetails = await _projectionGateway.FindAsync(user => user.UserName == query.UserName, cancellationToken);
            if(userDetails != null) 
            {
                if(userDetails.PassWord == query.PassWord)
                {
                    var result = new Projection.LoginUser
                    {
                        Id = userDetails.Id,
                        UserName = query.UserName,
                        PassWord = query.PassWord,
                        Role = userDetails.Role,
                        Token = GenerateToken(userDetails)
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

        private string GenerateToken(Projection.LoginUser userDetails)
        => "123";
    }
}
