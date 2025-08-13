using Application.Abstractions;
using Contracts.Abstractions.Protobuf;
using Contracts.Services.Payment;
using Contracts.Services.Payment.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService1.Services
{
    public class PaymentService : Paymenter.PaymenterBase
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly IInteractor<Query.GetPaymentByIdQuery, Projection.Payment> _interactor;
        public PaymentService(ILogger<PaymentService> logger,
            IInteractor<Query.GetPaymentByIdQuery, Projection.Payment> interactor)
        {
            _logger = logger;
            _interactor = interactor;
        }

        public override async Task<GetResponse> GetPaymentDetail(GetPaymentByIdRequest request, ServerCallContext context)
        {
            var payment = await _interactor.InteractAsync(request, context.CancellationToken);
            return payment is null
                ? new GetResponse { NotFound = new() }
                : new GetResponse { Projection = Any.Pack((PaymentDetails)payment) };
        }
    }
}
