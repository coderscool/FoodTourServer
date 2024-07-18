using Contracts.Services.ShoppingCart;
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
        [HttpDelete]
        public async Task<IActionResult> DeleteDishCart(Command.CheckAndRemoveDishCart request)
        {
            await _endpoint.Publish(request);
            return Ok();
        }
    }
}
