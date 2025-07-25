using Application.Abstractions;
using Contracts.Services.Restaurant;
using Grpc.Core;
using GrpcService1;

namespace GrpcService1.Services
{
    public class RestauranterService : Restauranter.RestauranterBase
    {
        private readonly ILogger<RestauranterService> _logger;
        public RestauranterService(ILogger<RestauranterService> logger)
        {
            _logger = logger;
        }
        
    }
}