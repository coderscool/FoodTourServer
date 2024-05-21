using Application.Abstractions;
using Contracts.Services.Identity;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        private readonly IInteractor<Query.Login, Projection.User> _getLoginUser;
        public GreeterService(ILogger<GreeterService> logger,
            IInteractor<Query.Login, Projection.User> getLoginUser)
        {
            _logger = logger;
            _getLoginUser = getLoginUser;
        }

        public override async Task<TokenReply> Login(LoginRequest request, ServerCallContext context)
        {
            var query = new Query.Login
            {
                UserName = request.UserName,
                PassWord = request.PassWord,
            };
            var result = await _getLoginUser.InteractAsync(query, context.CancellationToken);
            if(result == null)
            {
                return await Task.FromResult(new TokenReply
                {
                    Token = "Hello "
                });
            }
            return await Task.FromResult(new TokenReply
            {
                Token = result.Token
            });
        }
    }
}