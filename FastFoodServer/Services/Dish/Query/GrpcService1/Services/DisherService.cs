using Application.Abstractions;
using Contracts.Services.Dish;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;

namespace GrpcService1.Services
{
    public class DisherService : Disher.DisherBase
    {
        private readonly ILogger<DisherService> _logger;
        private readonly IPagedInteractor<Query.ListDishTredingQuery, Projection.Dish> _pagedInteractor;
        private readonly IInteractor<Query.DishDetailQuery, Projection.Dish> _interactor;
        public DisherService(ILogger<DisherService> logger, 
            IPagedInteractor<Query.ListDishTredingQuery, Projection.Dish> pagedInteractor,
            IInteractor<Query.DishDetailQuery, Projection.Dish> interactor)
        {
            _logger = logger;
            _pagedInteractor = pagedInteractor;
            _interactor = interactor;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override async Task<GetListDishReply> GetListDishTrending (GetListDishRequest request, ServerCallContext context)
        {
            var query = new Query.ListDishTredingQuery
            {
            };
            var result = await _pagedInteractor.InteractAsync(query, context.CancellationToken);
            if(result == null)
            {
                return null;
            }
            var list = result.Select(x => new DishDetailReply
            {
                Id = x.Id,
                RestaurantId = x.PersonId,
                Name = x.Name,
                Image = x.Image,
                Rate = x.Rate,
                Price = x.Cost
            });
            return await Task.FromResult(new GetListDishReply
            {
                List = { list }
            });
        }

        public override async Task<GetDishDetailReply> GetDishDetail(GetDishDetailRequest request, ServerCallContext context)
        {
            var query = new Query.DishDetailQuery
            {
                Id = request.Id,
                RestaurantId = request.RestaurantId,
            };
            var input = new GetUserRequest
            {
                Id = request.RestaurantId
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5123");
            var client = new Identiter.IdentiterClient(channel);
            var restaurant = await client.GetUserAsync(input);
            var result = await _interactor.InteractAsync(query, context.CancellationToken);
            if (result == null)
            {
                return null;
            }
            var dish = new DishDetailReply
            {
                Id = result.Id,
                RestaurantId = result.PersonId,
                Name = result.Name,
                Image = result.Image,
                Rate = result.Rate,
                Price = result.Cost
            };
            var res = new RestaurantReply
            {
                Name = restaurant.Name,
                Address = restaurant.Address,
                Phone = restaurant.Phone,
            };
            return await Task.FromResult(new GetDishDetailReply
            {
                Dish = dish,
                Restaurant = res
            });
        }
    }
}