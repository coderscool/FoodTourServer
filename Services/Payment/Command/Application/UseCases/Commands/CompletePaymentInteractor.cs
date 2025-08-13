using Application.Abstractions;
using Application.Services;
using Contracts.Services.Payment;
using Domain.Aggregates;

namespace Application.UseCases.Commands
{
    public class CompletePaymentInteractor : IInteractor<Command.CompletePayment>
    {
        private readonly IApplicationService _applicationService;
        public CompletePaymentInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public async Task InteractAsync(Command.CompletePayment command, CancellationToken cancellationToken)
        {
            var payment = await _applicationService.LoadAggregateAsync<Payment>(command.ItemId, cancellationToken);
            payment.Handle(command);
            await _applicationService.AppendEventsAsync(payment, cancellationToken);
        }
    }
}
