using Application.Abstractions;
using Contracts.Services.Restaurant;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class RestauranterService : Restauranter.RestauranterBase
    {
        private readonly ILogger<RestauranterService> _logger;
        private readonly IPagedInteractor<Query.GetListOrderRestaurantQuery, Projection.Restaurant> _pagedInteractor;
        public RestauranterService(ILogger<RestauranterService> logger,
            IPagedInteractor<Query.GetListOrderRestaurantQuery, Projection.Restaurant> pagedInteractor)
        {
            _logger = logger;
            _pagedInteractor = pagedInteractor;
        }
        public override async Task<GetOrderReply> GetListOrder(GetOrderRequest request, ServerCallContext context)
        {
            var query = new Query.GetListOrderRestaurantQuery
            {
                Id = request.Id,
            };
            var result = await _pagedInteractor.InteractAsync(query, context.CancellationToken);
            if(result == null)
            {
                return null;
            }
            var list = result.Select(x => new OrderDetail
            {
                Id = x.Id,
                RestaurantId = x.RestaurantId,
                CustomerId = x.CustomerId,
                DishId = x.DishId,
                Customer = new PersonDetail
                {
                    Name = x.Customer.Name,
                    Address = x.Customer.Address,
                    Phone = x.Customer.Phone,
                },
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
            });
            return await Task.FromResult(new GetOrderReply
            {
                List = { list }
            });
            
        }
    }
}