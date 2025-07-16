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
        public async Task<string> Generate(string Id, string Role, CancellationToken cancellationToken)
        {
            var singingCredentials = new SigningCredentials(
                key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secure_secret_key_1234567890")),
                algorithm: SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Id),
                new Claim(ClaimTypes.Role, Role)
            };

            var securityToken = new JwtSecurityToken(
                issuer: "https://localhost:44381",
                audience: "https://localhost:44381",
                claims: claims,
                signingCredentials: singingCredentials,
                expires: DateTimeOffset.Now.AddMinutes(60).DateTime
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
