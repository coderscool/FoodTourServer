using Contracts.Services.Dish;
using Grpc.Net.Client;
using GrpcService1;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Text;

namespace WebApi.Controllers.Dish
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IElasticClient _client;
        public DishController(IPublishEndpoint publishEndpoint, IElasticClient client)
        { 
            _publishEndpoint = publishEndpoint;
            _client = client;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromBody] Command.CreateDish request)
        {
            await _publishEndpoint.Publish(request);
            return Ok();
        }
        [HttpPost("/shop")]
        public async Task<IActionResult> AddDishInShoppingCart(Guid id)
        {

            return Ok();
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetListDishTrending()
        {
            var input = new GetListDishRequest
            {
                Id = "1"
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5286");
            var client = new Disher.DisherClient(channel);
            var reply = await client.GetListDishTrendingAsync(input);
            return Ok(reply);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetDishDetail([FromQuery] Query.DishDetailQuery request)
        {
            var input = new GetDishDetailRequest
            {
                Id = request.Id,
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5286");
            var client = new Disher.DisherClient(channel);
            var reply = await client.GetDishDetailAsync(input);
            return Ok(reply);
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> GetListDishRestaurant([FromQuery] Query.DishRestaurantQuery request)
        {
            var input = new GetListDishRestaurantRequest
            {
                Id = request.Id,
                Page = request.Page,
                Size = request.Size
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5286");
            var client = new Disher.DisherClient(channel);
            var reply = await client.GetListDishRestaurantAsync(input);
            return Ok(reply);
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchDish([FromBody] Query.SearchDishDetail request)
        {
            var input = new SearchDishRequest
            {
                Name = request.Name,
                Category = request.Category,
                Nation = request.Nation,
                Page = request.Page,
                Size = request.Size
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5286");
            var client = new Disher.DisherClient(channel);
            var reply = await client.SearchListDishRestaurantAsync(input);

            return Ok(reply);
        }
    }
}
