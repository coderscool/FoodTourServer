using Contracts.Services.Order;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Order
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public OrderController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost()]
        public async Task<IActionResult> AddItemOrder([FromBody] Command.AddItemOrder request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _publishEndpoint.Publish(request);
            return Ok("Success");
        }
    }
}
