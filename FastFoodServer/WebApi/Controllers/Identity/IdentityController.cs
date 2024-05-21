using Contracts.Services.Identity;
using Grpc.Net.Client;
using GrpcService1;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public async Task<IActionResult> RegisterUser([FromBody] Command.Register request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _publishEndpoint.Publish(request);
            return Ok("Success");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] Query.Login request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var input = new LoginRequest
            {
                UserName = request.UserName,
                PassWord = request.PassWord
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5123");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.LoginAsync(input);
            return Ok(reply);
        }

        [HttpGet("user")]
        [Authorize(Roles = "user")]
        public IActionResult GetUser()
        {
            return Ok("user");
        }

        [HttpGet("sale")]
        [Authorize(Roles = "sale")]
        public IActionResult GetSale()
        {
            return Ok("sale");
        }

    }
}
