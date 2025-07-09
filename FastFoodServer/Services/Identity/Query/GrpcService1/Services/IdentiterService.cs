using Application.Abstractions;
using Contracts.Services.Identity;
using Contracts.Services.Identity.Protobuf;
using Contracts.Abstractions.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class IdentiterService : Identiter.IdentiterBase
    {
        private readonly ILogger<IdentiterService> _logger;
        private readonly IInteractor<Query.Login, Projection.Identity> _getLoginUser;
        public IdentiterService(ILogger<IdentiterService> logger,
            IInteractor<Query.Login, Projection.Identity> getLoginUser)
        {
            _logger = logger;
            _getLoginUser = getLoginUser;
        }

        public override async Task<GetResponse> Login(LoginRequest request, ServerCallContext context)
        {
            var identity = await _getLoginUser.InteractAsync(request, context.CancellationToken);
            return identity is null
                ? new() { NotFound = new() }
                : new() { Projection = Any.Pack((IdentityDetails)identity) };
        }
    }
}