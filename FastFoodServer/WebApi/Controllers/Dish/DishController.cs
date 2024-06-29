using Contracts.Services.Dish;
using Grpc.Net.Client;
using GrpcService1;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApi.Controllers.Dish
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public DishController(IPublishEndpoint publishEndpoint)
        { 
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromBody] Command.CreateDish request)
        {
            await _publishEndpoint.Publish(request);
            Console.WriteLine("--send--");
            return Ok();
        }
        [HttpPost("/shop")]
        public async Task<IActionResult> AddDishInShoppingCart(Guid id)
        {

            return Ok();
        }
        [HttpGet("/list")]
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
    }
}
