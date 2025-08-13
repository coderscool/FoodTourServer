using Contracts.Abstractions.Messages;

namespace Contracts.Services.Identity
{
    public static class Projection
    {
        public record Identity(string Id, string UserName, string PassWord, string Role, string Token, long Version) : IProjection
        {
            public static implicit operator Protobuf.IdentityDetails(Identity identityDetails)
                => new()
                {
                    Id = identityDetails.Id,
                    Role = identityDetails.Role,
                    Token = identityDetails.Token
                };
        }
    }
}
