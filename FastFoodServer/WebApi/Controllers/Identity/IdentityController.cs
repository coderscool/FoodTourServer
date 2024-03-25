using Contracts.Services.Identity;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Identity
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase 
    {
        private readonly IPublishEndpoint _publishEndpoint;
        public IdentityController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        [HttpPost()]
        public async Task<IActionResult> RegisterUser([FromForm] Command.RegisterUser request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //await _publishEndpoint.Publish(request);
            return Ok("Success");
        }
    }
}
