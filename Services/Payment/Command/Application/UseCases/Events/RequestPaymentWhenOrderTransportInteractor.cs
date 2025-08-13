using Application.Abstractions;
using Application.Services;
using Order = Contracts.Services.Order;
using Domain.Aggregates;
using Contracts.Services.Payment;

namespace Application.UseCases.Events
{
    public class RequestPaymentWhenOrderTransportInteractor : IInteractor<Order.SummaryEvent.OrderTransport>
    {
        private readonly IApplicationService _applicationService;
        public RequestPaymentWhenOrderTransportInteractor(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public async Task InteractAsync(Order.SummaryEvent.OrderTransport @event, CancellationToken cancellationToken)
        {
            Payment payment = new();
            payment.Handle(new Command.RequestPayment(@event.Order.Group, @event.Order.PaymentMethod));
            await _applicationService.AppendEventsAsync(payment, cancellationToken);
        }
    }
}
