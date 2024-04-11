using Contracts.Services.Dish;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

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
            return Ok();
        }
        
    }
}
