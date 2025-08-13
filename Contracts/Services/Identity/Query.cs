using Contracts.Abstractions.Messages;
using Contracts.Abstractions.Paging;
using Contracts.Services.Identity.Protobuf;

namespace Contracts.Services.Identity
{
    public static class Query
    {
        public record Login(string Username, string Password) : IQuery
        {
            public static implicit operator Login(LoginRequest request)
                => new(request.UserName, request.PassWord);
        }
    }
}
