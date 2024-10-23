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
        private readonly IPagedInteractor<Query.DishRestaurantQuery, Projection.Dish> _pagedIndexInteractor;
        private readonly IPagedInteractor<Query.SearchDishDetail, Projection.Dish> _searchInteractor;
        public DisherService(ILogger<DisherService> logger, 
            IPagedInteractor<Query.ListDishTredingQuery, Projection.Dish> pagedInteractor,
            IInteractor<Query.DishDetailQuery, Projection.Dish> interactor,
            IPagedInteractor<Query.DishRestaurantQuery, Projection.Dish> pagedIndexInteractor,
            IPagedInteractor<Query.SearchDishDetail, Projection.Dish> searchInteractor)
        {
            _logger = logger;
            _pagedInteractor = pagedInteractor;
            _interactor = interactor;
            _pagedIndexInteractor = pagedIndexInteractor;
            _searchInteractor = searchInteractor;
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
                Price = x.Cost,
                Quantity = x.Quantity,
                Category = {x.Category},
                Nation = {x.Nation},
            });
            return await Task.FromResult(new GetListDishReply
            {
                List = { list }
            });
        }

        public override async Task<GetListDishReply> GetListDishRestaurant(GetListDishRestaurantRequest request, ServerCallContext context)
        {
            var query = new Query.DishRestaurantQuery
            {
                Id = request.Id,
                Page = request.Page,
                Size = request.Size,
            };
            var result = await _pagedIndexInteractor.InteractAsync(query, context.CancellationToken);
            if (result == null)
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
                Price = x.Cost,
                Quantity = x.Quantity,
                Category = { x.Category },
                Nation = { x.Nation },
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
            };
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
            var input = new GetUserRequest
            {
                Id = result.PersonId
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5123");
            var client = new Identiter.IdentiterClient(channel);
            var restaurant = await client.GetUserAsync(input);
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

        public override async Task<GetListDishReply> SearchListDishRestaurant(SearchDishRequest request, ServerCallContext context)
        {
            var query = new Query.SearchDishDetail
            {
                Name = request.Name,
                Category = request.Category,
                Nation = request.Nation,
                Page = request.Page,
                Size = request.Size,
            };
            var result = await _searchInteractor.InteractAsync(query, context.CancellationToken);
            if (result == null)
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
                Price = x.Cost,
                Quantity = x.Quantity,
                Category = { x.Category },
                Nation = { x.Nation },
            });
            return await Task.FromResult(new GetListDishReply
            {
                List = { list }
            });
        }
    }
}