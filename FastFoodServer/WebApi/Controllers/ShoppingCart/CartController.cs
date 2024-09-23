using Contracts.Services.ShoppingCart;
using Grpc.Net.Client;
using GrpcService1;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ShoppingCart
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IPublishEndpoint _endpoint;
        public CartController(IPublishEndpoint endpoint)
        {
            _endpoint = endpoint;
        }
        [HttpPost]
        public async Task<IActionResult> AddShoppingCart(Command.AddCartItem request)
        {
            await _endpoint.Publish(request);
            return Ok();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteDishCart(Command.CheckAndRemoveDishCart request)
        {
            await _endpoint.Publish(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> IncreaseQuantityCart(Command.IncreaseQuantityCart request)
        {
            await _endpoint.Publish(request);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerCart([FromQuery] Query.CustomerCartQuery request)
        {
            var input = new GetListCartRequest
            {
                CustomerId = request.CustomerId,
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5162");
            var client = new Carter.CarterClient(channel);
            var reply = await client.ListDishCartQueryAsync(input);
            return Ok(reply);
        }
    }
}
