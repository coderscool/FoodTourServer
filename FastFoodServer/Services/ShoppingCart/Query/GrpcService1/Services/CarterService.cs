using Application.Abstractions;
using Contracts.Services.ShoppingCart;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;

namespace GrpcService1.Services
{
    public class CarterService : Carter.CarterBase
    {
        private readonly ILogger<CarterService> _logger;
        private readonly IPagedInteractor<Query.CustomerCartQuery, Projection.Cart> _pagedInteractor;
        public CarterService(ILogger<CarterService> logger,
            IPagedInteractor<Query.CustomerCartQuery, Projection.Cart> pagedInteractor)
        {
            _logger = logger;
            _pagedInteractor = pagedInteractor;
        }

        public override async Task<GetListCartReply> ListDishCartQuery(GetListCartRequest request, ServerCallContext context)
        {
            var list = new List<GetCartDetail>();
            var result = await _pagedInteractor.InteractAsync(new Query.CustomerCartQuery { CustomerId = request.CustomerId }, context.CancellationToken);
            if(result == null)
            {
                return null;
            }
            foreach(var item in result)
            {
                var input1 = new GetDishDetailRequest
                {
                    Id = item.DishId
                };
                var channel1 = GrpcChannel.ForAddress("http://localhost:5286");
                var client1 = new Disher.DisherClient(channel1);
                var dish = await client1.GetDishDetailAsync(input1);
                var res = new CartRestaurantReply
                {
                    Name = dish.Restaurant.Name,
                    Address = dish.Restaurant.Address,
                    Phone = dish.Restaurant.Phone,
                };
                var cart = new GetCartDetail
                {
                    Id = item.Id,
                    RestaurantId = item.RestaurantId,
                    CustomerId = item.CustomerId,
                    DishId = item.DishId,
                    Restaurant = res,
                    Name = dish.Dish.Name,
                    Image = dish.Dish.Image,
                    Price = dish.Dish.Price,
                    Quantity = item.Amount
                };
                Console.WriteLine(cart);
                list.Add(cart);
            }
            return await Task.FromResult(new GetListCartReply
            {
                List = {list}
            });
        }
    }
}