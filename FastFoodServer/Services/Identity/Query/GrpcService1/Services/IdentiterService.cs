using Application.Abstractions;
using Contracts.Services.Identity;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class IdentiterService : Identiter.IdentiterBase
    {
        private readonly ILogger<IdentiterService> _logger;
        private readonly IInteractor<Query.Login, Projection.User> _getLoginUser;
        private readonly IInteractor<Query.GetUserRequest, Projection.User> _getUser;
        public IdentiterService(ILogger<IdentiterService> logger,
            IInteractor<Query.Login, Projection.User> getLoginUser,
            IInteractor<Query.GetUserRequest, Projection.User> getUser)
        {
            _logger = logger;
            _getLoginUser = getLoginUser;
            _getUser = getUser;
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
                    Token = "Hello ",
                    Role = "word"
                });
            }
            return await Task.FromResult(new TokenReply
            {
                Token = result.Token,
                Role = result.Role
            });
        }

        public override async Task<GetUserReply> GetUser(GetUserRequest request, ServerCallContext context)
        {
            var query = new Query.GetUserRequest
            {
                Id = request.Id,
            };
            var result = await _getUser.InteractAsync(query, context.CancellationToken);
            if (result == null)
            {
                return null;
            }
            return await Task.FromResult(new GetUserReply
            {
                Id = result.Id,
                Name = result.Name,
                Address = result.Address,
                Phone = result.Phone,
                Role = result.Role,
            });
        }
    }
}