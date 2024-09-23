using Contracts.Services.Restaurant;
using Grpc.Net.Client;
using GrpcService1;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Restaurant
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public RestaurantController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetListOrderRestaurant([FromQuery] Query.GetListOrderRestaurantQuery request)
        {
            var input = new GetOrderRequest
            {
                Id = request.Id,
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5248");
            var client = new Restauranter.RestauranterClient(channel);
            var reply = await client.GetListOrderAsync(input);
            return Ok(reply);
        }

        [HttpPost]
        public async Task<IActionResult> ReplyRestaurant([FromBody] Command.ReplyRestaurant request)
        {
            await _publishEndpoint.Publish(request);
            return Ok();
        }
    }
}
