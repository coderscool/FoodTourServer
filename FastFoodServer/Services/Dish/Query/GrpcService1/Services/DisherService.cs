using Application.Abstractions;
using Contracts.Services.Dish;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class DisherService : Disher.DisherBase
    {
        private readonly ILogger<DisherService> _logger;
        private readonly IPagedInteractor<Query.DishDetailQuery, Projection.Dish> _pagedInteractor;
        public DisherService(ILogger<DisherService> logger, IPagedInteractor<Query.DishDetailQuery, Projection.Dish> pagedInteractor)
        {
            _logger = logger;
            _pagedInteractor = pagedInteractor;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override async Task<GetListDishReply> GetListDish (GetListDishRequest request, ServerCallContext context)
        {
            var query = new Query.DishDetailQuery
            {
                Id = request.Id,
            };
            var result = await _pagedInteractor.InteractAsync(query, context.CancellationToken);
            if(result == null)
            {
                return null;
            }
            var list = result.Select(x => new DishDetailReply
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
                Adress = "ha noi",
                Rate = x.Rate,
                Price = x.Cost
            });
            return await Task.FromResult(new GetListDishReply
            {
                List = { list }
            });
        }
    }
}