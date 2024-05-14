using Contracts.Services.Dish;
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
            Console.WriteLine(request.Dish.Name);
            return Ok();
        }
        [HttpPost("/shop")]
        public async Task<IActionResult> AddDishInShoppingCart(Guid id)
        {

            return Ok();
        }
        private static async Task SaveFile(byte[] file)
        {
            // In mảng byte
            foreach (byte b in file)
            {
                Console.Write($"{b:X2} "); // In byte dưới dạng hex
            }
        }
    }
}
