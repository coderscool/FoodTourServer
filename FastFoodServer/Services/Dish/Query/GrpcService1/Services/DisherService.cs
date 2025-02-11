using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Dish;
using Contracts.Services.Dish.Protobuf;
using Contracts.Services.Identity.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcService1;

namespace GrpcService1.Services
{
    public class DisherService : Disher.DisherBase
    {
        private readonly ILogger<DisherService> _logger;
        private readonly IInteractor<Query.DishDetailsById, Projection.Dishs> _interactor;
        public DisherService(ILogger<DisherService> logger,
            IInteractor<Query.DishDetailsById, Projection.Dishs> interactor)
        {
            _logger = logger;
            _interactor = interactor;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }

        public override async Task<GetResponse> GetDishDetailsById(DishDetailsByIdRequest request, ServerCallContext context)
        {
            var userDetails = await _interactor.InteractAsync(request, context.CancellationToken);
            return userDetails is null
            ? new() { NotFound = new() }
            : new() { Projection = Any.Pack((DishDetails)userDetails) };
        }
    }
}