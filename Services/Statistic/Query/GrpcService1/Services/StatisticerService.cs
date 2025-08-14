using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Statistic;
using Contracts.Services.Statistic.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class StatisticerService : Statisticer.StatisticerBase
    {
        private readonly ILogger<StatisticerService> _logger;
        private readonly IInteractor<Query.GetById, Projection.StatisticSeller> _interactor;
        public StatisticerService(ILogger<StatisticerService> logger,
            IInteractor<Query.GetById, Projection.StatisticSeller> interactor)
        {
            _logger = logger;
            _interactor = interactor;
        }

        public override async Task<GetResponse> GetStatisticDetail(GetByIdRequest request, ServerCallContext context)
        {
            var statistic = await _interactor.InteractAsync(request, context.CancellationToken);
            return statistic is null
                ? new GetResponse { NotFound = new() }
                : new GetResponse { Projection = Any.Pack((StatisticDetail)statistic) };
        }
    }
}