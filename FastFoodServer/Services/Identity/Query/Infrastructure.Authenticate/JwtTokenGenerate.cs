using Application.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authenticate
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public JwtTokenGenerator()
        {
        }

        public async Task<string> Generate(string UserName, string Role, CancellationToken cancellationToken)
        {
            var singingCredentials = new SigningCredentials(
                key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0123456789ABCDEF")),
                algorithm: SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, Role)
            };

            var securityToken = new JwtSecurityToken(
                issuer: "https://localhost:44381",
                audience: "https://localhost:44381",
                claims: claims,
                signingCredentials: singingCredentials,
                expires: DateTimeOffset.Now.AddMinutes(5).DateTime
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
