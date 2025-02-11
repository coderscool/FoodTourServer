using Contracts.Services.Identity;
using Contracts.Services.Identity.Protobuf;
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
        [HttpGet("infor")]
        public async Task<IActionResult> GetUser([FromForm] Query.GetUserRequest request)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var input = new GetUserRequest
                {
                    Id = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                };
                var channel = GrpcChannel.ForAddress("http://localhost:5123");
                var client = new Identiter.IdentiterClient(channel);
                var reply = await client.GetUserAsync(input);
                return Ok(reply);
            }
            else
            {
                return Ok(null);
            }
        }
        [HttpGet("test")]
        public async Task<IActionResult> GetUserInfor([FromQuery] Query.GetUserRequest request)
        {

            var input = new GetUserRequest
            {
                Id = request.Id,
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5123");
            var client = new Identiter.IdentiterClient(channel);
            var reply = await client.GetUserAsync(input);
            return Ok(reply);
        }

        [HttpPost("store")]
        public async Task<IActionResult> GetListRestaurant([FromBody] Query.GetRestaurantRequest request)
        {
            var input = new StoreRequest
            {
                Key = request.Key,
                Nation = request.Nation,
                Location = request.Location,
                Page = request.Page,
                Size = request.Size
            };
            var channel = GrpcChannel.ForAddress("http://localhost:5123");
            var client = new Identiter.IdentiterClient(channel);
            var reply = await client.GetListRestaurantAsync(input);
            return Ok(reply);
        }
    }
}
