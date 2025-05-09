using Application.Abstractions;
using Contracts.Services.Cart.Protobuf;
using Contracts.Services.ShoppingCart;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;

namespace GrpcService1.Services
{
    public class CarterService : Carter.CarterBase
    {
        private readonly ILogger<CarterService> _logger;
        
        public CarterService(ILogger<CarterService> logger)
        {
            _logger = logger;
        }
    }
}