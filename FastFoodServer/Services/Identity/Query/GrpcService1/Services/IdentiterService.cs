using Application.Abstractions;
using Contracts.Services.Identity;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;

namespace GrpcService1.Services
{
    public class IdentiterService : Identiter.IdentiterBase
    {
        private readonly ILogger<IdentiterService> _logger;
        private readonly IInteractor<Query.Login, Projection.User> _getLoginUser;
        private readonly IInteractor<Query.GetUserRequest, Projection.User> _getUser;
        private readonly IPagedInteractor<Query.GetRestaurantRequest, Projection.User> _getRestaurant;
        public IdentiterService(ILogger<IdentiterService> logger,
            IInteractor<Query.Login, Projection.User> getLoginUser,
            IInteractor<Query.GetUserRequest, Projection.User> getUser,
            IPagedInteractor<Query.GetRestaurantRequest, Projection.User> getRestaurant)
        {
            _logger = logger;
            _getLoginUser = getLoginUser;
            _getUser = getUser;
            _getRestaurant = getRestaurant;
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
            var input = new AccountRequest
            {
                Id = request.Id
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5061");
            var client = new Accounter.AccounterClient(channel);
            var reply = await client.GetBudgetAccountAsync(input);
            return await Task.FromResult(new GetUserReply
            {
                Id = result.Id,
                Name = result.Person.Name,
                Address = result.Person.Address,
                Phone = result.Person.Phone,
                Role = result.Role,
                Budget = reply.Budget,
                Image = result.Image
            });
        }

        public override async Task<ListStoreReply> GetListRestaurant(StoreRequest request, ServerCallContext context)
        {
            var query = new Query.GetRestaurantRequest
            {
                Key = request.Key,
                Nation = request.Nation,
                Location = request.Location,
                Page = request.Page,
                Size = request.Size,
            };
            var result = await _getRestaurant.InteractAsync(query, context.CancellationToken);
            if (result == null)
            {
                return null;
            }

            var list = result.Select(x => new StoreReply
            {
                Id = x.Id,
                Name = x.Person.Name,
                Image = x.Image,
                Address = x.Person.Address,
            });
            return await Task.FromResult(new ListStoreReply
            {
                List = { list }
            });
        }
    }
}